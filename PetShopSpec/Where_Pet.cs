using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Training.DomainClasses;

namespace Training.Specificaton
{
    internal static class Where_Pet
    {
        public static CriteriaBuilder HasAn(Func<Pet, Species> propertySelector)
        {
            return new CriteriaBuilder(propertySelector);
        }
    }

    internal class CriteriaBuilder
    {
        private Func<Pet, Species> _propertySelector;
        public CriteriaBuilder(Func<Pet, Species> propertySelector)
        {
            _propertySelector = _propertySelector;
        }

        public Criteria<Pet> EqualTo(Species species)
        {
            return new AnonymousCriteria<Pet>(pet => _propertySelector(pet) == species);
        }
    }
}