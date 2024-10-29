using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
            var cats = new List<Pet>();
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    cats.Add(pet);
                }
            }
            return cats;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var pets = new List<Pet>(_petsInTheStore);
            pets.Sort(new Comparison<Pet>(((pet, pet1) => pet.name.CompareTo(pet1.name))));
            return pets;
        }
    }
}