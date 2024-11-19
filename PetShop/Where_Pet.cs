using System;
using Training.DomainClasses;

public class Where_Pet
{
    public static CriteriaBuilder HasAn(Func<Pet, Species> propertySelector)
    {
        return new CriteriaBuilder(propertySelector);
    }
}