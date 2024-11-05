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
	        foreach (var pet1 in _petsInTheStore.AllThat((pet => pet.species==Species.Cat))) yield return pet1;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
	        return _petsInTheStore.AllThat((pet => pet.species == Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
	        return _petsInTheStore.AllThat((pet => pet.sex == Sex.Female));
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
	        return _petsInTheStore.AllThat((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
	        return _petsInTheStore.AllThat((pet => pet.species != Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
	        return _petsInTheStore.AllThat((pet => pet.yearOfBirth > 2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
	        return _petsInTheStore.AllThat((pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
	        return _petsInTheStore.AllThat((pet => pet.sex == Sex.Male && pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
	        return _petsInTheStore.AllThat((pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit));
		}
    }
}