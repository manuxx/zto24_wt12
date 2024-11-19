using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
	public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (TItem pet in items)
        {
            if (criteria.IsSatisfiedBy(pet))
                yield return pet;
        }
    }
}