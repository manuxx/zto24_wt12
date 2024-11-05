using System;
using System.Collections.Generic;
using System.Reflection;
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

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> TItemsInTheStore, Predicate<TItem> condition)
    {
        return TItemsInTheStore.AllThat<TItem>(new AnonymousCriteria<TItem>(condition)); // Adapter
    }

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (TItem item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<TItem> : Criteria<TItem>
{
    private Predicate<TItem> _condition;
    public AnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}