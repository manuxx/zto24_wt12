using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {

            if (!_petsInTheStore.Contains(newPet))
            {
                _petsInTheStore.Add(newPet);

            }
        }

        public IEnumerable<Pet> AllCats()
        {
            return AllThat(_petsInTheStore, pet => pet.species==Species.Cat);
        }

        

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllThat(_petsInTheStore, pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllThat(_petsInTheStore, pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllThat(_petsInTheStore, pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllThat(_petsInTheStore, pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllThat(_petsInTheStore, pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllThat(_petsInTheStore, pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllThat(_petsInTheStore, pet => pet.species == Species.Dog && pet.sex == Sex.Male);

        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllThat(_petsInTheStore, pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011);
        }

        public static IEnumerable<Pet> AllThat(IList<Pet> petsInTheStore, Predicate<Pet> condition)
        {
            foreach (Pet pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }
    }
}