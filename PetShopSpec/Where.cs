using System;

namespace Training.DomainClasses
{
    public class Where
    {
        public static CriteriaBuilder HasAn(Func<Pet, Species> propertySelector)
        {
            return new CriteriaBuilder(propertySelector);
        }
    }

    public class CriteriaBuilder
    {
        private readonly Func<Pet, Species> _propertySelector;

        public CriteriaBuilder(Func<Pet, Species> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<Pet> EqualTo(Species cat)
        {
            return new AnonymousCriteria<Pet>((pet => _propertySelector(pet) == cat));
        }
    }
}