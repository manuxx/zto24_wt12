using System;
using Training.DomainClasses;

public class CriteriaBuilder
{
    private readonly Func<Pet, Species> _propertySelector;

    public CriteriaBuilder(Func<Pet, Species> propertySelector)
    {
        _propertySelector = propertySelector;
    }

    public Criteria<Pet> EqualsTo(Species species)
    {
        return new AnonymousCriteria<Pet>(pet => _propertySelector(pet) == species);
    }
}