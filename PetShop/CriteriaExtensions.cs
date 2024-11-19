namespace Training.DomainClasses
{
    public static class CriteriaExtensions
    {
        public static Alternative<TItem> Or<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            return new Alternative<TItem>(criteria1, criteria2);
        }

        public static Conjuction<TItem> And<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
        {
            return new Conjuction<TItem>(criteria1, criteria2);
        }
    }
}