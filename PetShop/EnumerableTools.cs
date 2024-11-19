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
    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> criteria)
    {
        foreach (TItem item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}