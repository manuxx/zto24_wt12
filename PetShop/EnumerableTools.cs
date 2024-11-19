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

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> petsInTheStore, Predicate<TItem> condition)
    {
        return petsInTheStore.AllThat(new AnonymousCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> petsInTheStore, Criteria<TItem> criteria)
    {
        foreach (TItem item in petsInTheStore)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T pet)
    {
        return _condition(pet);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T pet);
}