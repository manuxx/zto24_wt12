using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<Pet> AllThat<Pet>(this IEnumerable<Pet> petsInTheStore, Predicate<Pet> condition)
    {
        return petsInTheStore.AllThat(new AnonymousCriteria<Pet>(condition));
    }
    public static IEnumerable<Pet> AllThat<Pet>(this IEnumerable<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
        foreach (Pet pet in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(pet))
                yield return pet;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    public AnonymousCriteria(Predicate<T> condition)
    {
        throw new NotImplementedException();
    }

    public bool IsSatisfiedBy<T1>(T1 pet)
    {
        throw new NotImplementedException();
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy<T>(T pet);
}