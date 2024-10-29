using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
    public static IEnumerable<TItem> AllItems<TItem>(IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}