namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {

        public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : base(criteria1, criteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem pet)
        {
            return _criteria1.IsSatisfiedBy(pet) || _criteria2.IsSatisfiedBy(pet);
        }
    }
}