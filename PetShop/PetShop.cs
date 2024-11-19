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
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Cat));
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var ret = new List<Pet>(_petsInTheStore);
            ret.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            return ret;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllThat(Pet.IsSpeciesOf(Species.Mouse));
            
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllThat(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllThat(new Alternative(Pet.IsSpeciesOf(Species.Cat),Pet.IsSpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllThat(new Negation<Pet>(Pet.IsSpeciesOf(Species.Mouse)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllThat(new Conjunction<Pet>(Pet.IsSpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllThat((pet => pet.species == Species.Dog && pet.sex ==Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllThat((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));
        }
    }

    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria;

        public Negation(Criteria<TItem> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(TItem pet)
        {
            return !_criteria.IsSatisfiedBy(pet);
        }
    }
}