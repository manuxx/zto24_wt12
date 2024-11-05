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

    public static IEnumerable<T> AllThat<T>(this IEnumerable<T> petsInTheStore, Func<T, bool> condition)
    {
        foreach (var pet in petsInTheStore)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}