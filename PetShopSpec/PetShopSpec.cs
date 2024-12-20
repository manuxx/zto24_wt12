﻿using System;
using System.Collections.Generic;
using Training.DomainClasses;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Training.Specificaton
{

    class MyClass
    {
        static int res = 0;

        private Establish it = () =>
        {
            res = 2;
        };
        private Because of = () => { res += 2; };
        private It should_be_that_two_plus_two_is_four = ()=>
        {
            
            res.ShouldEqual(4);
        };
}
    public abstract class pet_shop_concern : Specification<PetShop>
    {
        Establish context = () =>
        {
            pet_initial_content = new List<Pet>();
            ProvideBasicConstructorArgument(pet_initial_content);
        };

        protected static IList<Pet> pet_initial_content;
    }

    public class when_counting_pets_in_the_shop : pet_shop_concern
    {
        Establish context = () =>
        {
            pet_initial_content.AddManyItems(new Pet(), new Pet());
        };
        Because of = () =>
        {
            number_of_pets = subject.AllPets().CountItems();
        };
        static int number_of_pets;

        It should_return_the_number_of_all_pets_in_the_shop = () =>
            number_of_pets.ShouldEqual(2);
    }


    public class when_adding_a_new_pet : pet_shop_concern
    {
        Establish context = () => pet = new Pet();
        Because of = () => subject.Add(pet);

        It should_store_a_new_pet_in_the_shop = () =>
            subject.AllPets().ShouldContain(pet);

        static Pet pet;
    }

	
	public class when_adding_an_existing_pet_again_ : pet_shop_concern
    {
        Establish context = () =>
        {
            pet = new Pet();
            pet_initial_content.Add(pet);
        };

        Because of = () =>
            subject.Add(pet);

        It should_store_a_pet_in_the_shop_once = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static Pet pet;
    }


	public class when_adding_a_new_pet_with_existing_name_ : pet_shop_concern
    {
        Establish context = () =>
        {
            fluffy_the_first = new Pet { name = "Fluffy" };
            fluffy_the_second = new Pet { name = "Fluffy" };
            pet_initial_content.Add(fluffy_the_first);
        };

        Because of = () => subject.Add(fluffy_the_second);

        It should_contain_only_one_pet_of_the_name_in_the_store = () =>
            subject.AllPets().CountItems().ShouldEqual(1);

        private static Pet fluffy_the_first;
        private static Pet fluffy_the_second;
    }
    [Subject(typeof(PetShop))]
    class when_trying_to_change_returned_collection_of_pets : pet_shop_concern
    {
        Establish c = () => pet_initial_content.AddManyItems(new Pet { name = "Pixie" }, new Pet { name = "Dixie" });
        Because b = () =>
        {
            IEnumerable<Pet> returned_pets = subject.AllPets();
            exception = Catch.Exception(() => { var x = (ICollection<Pet>)returned_pets; });
        };
        private static IEnumerable<Pet> returned_collection_of_pets;
        private static Exception exception;
        It invalid_cast_exception_should_be_thrown = () => exception.ShouldBeOfExactType<InvalidCastException>();
    }
    public class concern_with_pets_for_sorting_and_filtering : pet_shop_concern
    {
        private Establish c = () =>
        {
            mouse_Dixie = new Pet
            {
                name = "Dixie",
                species = Species.Mouse,
                price = 10,
                sex = Sex.Female,
                yearOfBirth = 2011
            };
            mouse_Jerry = new Pet
            {
                name = "Jerry",
                species = Species.Mouse,
                price = 5,
                sex = Sex.Male,
                yearOfBirth = 2012
            };

            cat_Tom = new Pet
            {
                name = "Tom",
                species = Species.Cat,
                price = 30,
                sex = Sex.Male,
                yearOfBirth = 2010
            };
            cat_Jinx = new Pet
            {
                name = "Jinx",
                species = Species.Cat,
                price = 40,
                sex = Sex.Male,
                yearOfBirth = 2009
            };
            rabbit_Fluffy = new Pet
            {
                name = "Fluffy",
                species = Species.Rabbit,
                price = 35,
                sex = Sex.Male,
                yearOfBirth = 2011
            };
            dog_Huckelberry = new Pet
            {
                name = "Huckelberry",
                species = Species.Dog,
                price = 80,
                sex = Sex.Male,
                yearOfBirth = 2008
            };
            dog_Lassie = new Pet
            {
                name = "Lassie",
                species = Species.Dog,
                price = 150,
                sex = Sex.Female,
                yearOfBirth = 2007
            };
            dog_Pluto = new Pet
            {
                name = "Pluto",
                species = Species.Dog,
                price = 100,
                sex = Sex.Male,
                yearOfBirth = 2011
            };
            pet_initial_content.AddManyItems(cat_Tom,
                                             cat_Jinx,
                                             dog_Huckelberry,
                                             dog_Lassie,
                                             dog_Pluto,
                                             rabbit_Fluffy,
                                             mouse_Dixie,
                                             mouse_Jerry);
        };


        protected static Pet cat_Jinx;
        protected static Pet mouse_Dixie;
        protected static Pet mouse_Jerry;
        protected static Pet rabbit_Fluffy;
        protected static Pet cat_Tom;
        protected static Pet dog_Huckelberry;
        protected static Pet dog_Lassie;
        protected static Pet dog_Pluto;
    }

    public class when_searching_for_pets : concern_with_pets_for_sorting_and_filtering
    {
        private It should_be_able_to_find_all_cats = () =>
        {
            Criteria<Pet> criteria = Where_Pet.HasAn(pet => pet.species).EqualTo(Species.Cat);
            var foundPets = subject.AllPets().AllThat(criteria);
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx);
        };
        private It should_be_able_to_find_all_mice = () =>
        {
            var foundPets = subject.AllMice();
            foundPets.ShouldContainOnly(mouse_Dixie, mouse_Jerry);
        };

        private It should_be_able_to_find_all_female_pets = () =>
        {
            var foundPets = subject.AllFemalePets();
            foundPets.ShouldContainOnly(dog_Lassie, mouse_Dixie);
        };

        private It should_be_able_to_find_all_cats_or_dogs = () =>
        {
            var foundPets = subject.AllCatsOrDogs();
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx, dog_Huckelberry, dog_Lassie, dog_Pluto);
        };
        private It should_be_able_to_find_all_pets_but_not_mice = () =>
        {
            var foundPets = subject.AllPetsButNotMice();
            foundPets.ShouldContainOnly(cat_Tom, cat_Jinx, dog_Huckelberry, dog_Lassie, dog_Pluto, rabbit_Fluffy);
        };
        private It should_be_able_to_find_all_pets_born_after_2010 = () =>
        {
            var foundPets = subject.AllPetsBornAfter2010();
            foundPets.ShouldContainOnly(dog_Pluto, rabbit_Fluffy, mouse_Dixie, mouse_Jerry);
        };
        private It should_be_able_to_find_all_young_dogs = () =>
        {
            var foundPets = subject.AllDogsBornAfter2010();
            foundPets.ShouldContainOnly(dog_Pluto);
        };
        private It should_be_able_to_find_all_male_dogs = () =>
        {
            var foundPets = subject.AllMaleDogs();
            foundPets.ShouldContainOnly(dog_Huckelberry, dog_Pluto);
        };
        private It should_be_able_to_find_all_young_pets_or_rabbits = () =>
        {
            var foundPets = subject.AllPetsBornAfter2011OrRabbits();
            foundPets.ShouldContainOnly(mouse_Jerry, rabbit_Fluffy);
        };

    }

    internal class Where_Pet
    {
        public static CriteriaBuilder HasAn(Func<Pet, Species> func)
        {
            return new CriteriaBuilder();
        }
    }

    internal class CriteriaBuilder
    {
        public Criteria<Pet> EqualTo(Species cat)
        {
            throw new NotImplementedException();
        }
    }


    class when_sorting_pets : concern_with_pets_for_sorting_and_filtering
    {
        It should_be_able_to_sort_by_name_ascending = () =>
        {
            var result = subject.AllPetsSortedByName();
            result.ShouldContainOnlyInOrder(mouse_Dixie, rabbit_Fluffy, dog_Huckelberry, mouse_Jerry, cat_Jinx,
                dog_Lassie,
                dog_Pluto, cat_Tom);
        };
    };

}