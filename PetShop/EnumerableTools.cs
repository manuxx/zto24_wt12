using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableTools
{
    public static IEnumerable<Pet> OneAtTime(IEnumerable<Pet> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}