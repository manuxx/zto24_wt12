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
            // foreach (Pet pet in _petsInTheStore)
            // {
            //     
            // }
            return _petsInTheStore.OneAtATime().OrderBy(cat => cat.name);
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