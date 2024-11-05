using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Training.DomainClasses;
using static EnumerableTools;

public static class EnumerableTools
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<Pet> AllThat(this IEnumerable<Pet> petsInTheStore, Predicate<Pet> condition)
    {
	    return petsInTheStore.AllThat(new AnonymousCriteria<Pet>(condition));
    }

    public static IEnumerable<Pet> AllThat(this IEnumerable<Pet> petsInTheStore, Criteria<Pet> criteria)
    {
		foreach (var pet in petsInTheStore)
		{
			if (criteria.IsSatisfiedBy(pet))
				yield return pet;
		}
	}

	public interface Criteria<T>
    {
	    bool IsSatisfiedBy(T item);
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
	public Predicate<T> condition;
	public AnonymousCriteria(Predicate<T> condition)
	{
		this.condition = condition;
	}

	public bool IsSatisfiedBy(T item)
	{
		return condition(item);
	}
}