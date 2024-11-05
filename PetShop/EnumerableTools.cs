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

    public static IEnumerable<Pet> AllThat<Pet>(this IEnumerable<Pet> items, Func<Pet, bool> condition)
    {
        return items.AllThat(new AnonymousCriteria<Pet>(condition));
    }

    public static IEnumerable<Pet> AllThat<Pet>(this IEnumerable<Pet> items, Criteria<Pet> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private Func<T, bool> _condition;

    public AnonymousCriteria(Func<T, bool> condition)
    {
        _condition = condition;
        //throw new NotImplementedException();
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}