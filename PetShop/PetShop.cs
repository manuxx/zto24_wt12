using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);
            
            // Sort is not a Linq its by default in enumerable
            sortedPets.Sort((p1,p2) => p1.name.CompareTo(p2.name));
            
            return sortedPets;

            // uses Linq, not allowed on labs
            // return _petsInTheStore.OneAtATime().OrderBy(cat => cat.name);
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (Pet pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
            
            // uses Linq, not allowed on labs
            // return _petsInTheStore.OneAtATime().Where(cat => cat.species == Species.Cat);


        }
    }
}