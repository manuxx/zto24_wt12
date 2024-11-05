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

    public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Predicate<TItem> meetsCondition)
    {
        foreach (var item in items)
        {
            if (meetsCondition(item))
            {
                yield return item;
            }
        }
    }
}