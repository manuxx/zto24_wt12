using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
	public static IEnumerable<TItem> AllThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (TItem item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}