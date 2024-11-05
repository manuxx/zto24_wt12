using System;
using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableTools
{

    public static IEnumerable<Pet> AllThat(this IList<Pet> petsInTheStore, Func<Pet, bool> condition)
    {
        return petsInTheStore.AllThat(new AnonymousCriteria<Pet>(condition));
    }

    public static IEnumerable<Pet> AllThat(this IList<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
        foreach (var pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
            {
                yield return pet;
            }
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private Func<Pet, bool> _condition;

    public AnonymousCriteria(Func<Pet, bool> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(Pet pet)
    {
        if(_condition(pet)) return true;
        return false;
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(Pet pet);
}