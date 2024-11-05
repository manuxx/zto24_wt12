using System;
using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableTools
{
    public static IEnumerable<Pet> AllThat(this IList<Pet> petsInTheStore, Func<Pet, bool> condition)
    {
        foreach (var pet in petsInTheStore)
        {
            if (condition(pet))
            {
                yield return pet;
            }
        }
    }
}