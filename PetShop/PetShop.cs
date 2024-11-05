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
            foreach (Pet pet in _petsInTheStore)
            {
                if(pet.species==Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return ret;
        }

        private IEnumerable<Pet> AllThat(Func<Pet, bool> condition)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (condition(pet))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllThat(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllThat(pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllThat(pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllThat(pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllThat(pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllThat(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllThat(pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllThat(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }
}