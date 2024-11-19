using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Training.DomainClasses;

namespace Training.Specificaton
{
    internal static class Where_Pet
    {
        public static CriteriaBuilder HasAn(Func<Pet, Species> unknown)
        {
            return new CriteriaBuilder();
        }
    }

    internal class CriteriaBuilder
    {
        public Criteria<Pet> EqualTo(Species cat)
        {
            throw new NotImplementedException();
        }
    }
}