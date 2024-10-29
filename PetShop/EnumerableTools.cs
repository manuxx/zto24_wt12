using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableTools
    {
        public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}