using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerateTools
    {

        public static IEnumerable<Pet> OneAtATime(this IEnumerable<Pet> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}