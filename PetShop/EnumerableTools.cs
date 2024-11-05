using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
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

    public static IEnumerable<Pet> AllThat(this IEnumerable<Pet> pets, Func<Pet, bool> condition)
    {
        return pets.AllThat(new AnonymousCriteria<Pet>(condition));
    }

    public static IEnumerable<Pet> AllThat(this IEnumerable<Pet> pets, Critertia<Pet> critertia)
    {
        foreach (Pet pet in pets)
        {
            if (critertia.IsSatisfiedBy(pet)) yield return pet;
        }
    }
}

public class AnonymousCriteria<T> : Critertia<T>
{
    private Func<T, bool> _condition;
    public AnonymousCriteria(Func<T, bool> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Critertia<T>
{
    bool IsSatisfiedBy(T item);
}