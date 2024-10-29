using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
    //ctrl+shift+r = refactor
    //ctrl+shift+g = navigate to
    //extension only for public class&method and method static
    public static IEnumerable<TItem> OneAtTime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}