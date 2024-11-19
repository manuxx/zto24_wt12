using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class CriteriaTools
    {
        public static Alternative<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> isSpeciesOf)
        {
            return new Alternative<TItem>(criteria1, isSpeciesOf);
        }
    }
}