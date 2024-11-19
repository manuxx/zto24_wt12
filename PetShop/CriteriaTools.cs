using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
    public static class CriteriaTools
    {
        public static Criteria<TItem> Or<TItem>(this Criteria<TItem> baseCriteria, Criteria<TItem> orCriteria)
        {
            return new Alternative<TItem>(baseCriteria, orCriteria);
        }

        public static Criteria<TItem> And<TItem>(this Criteria<TItem> baseCriteria, Criteria<TItem> orCriteria)
        {
            return new Conjuction<TItem>(baseCriteria, orCriteria);
        }
    }
}
