namespace Training.DomainClasses
{
	public abstract class BinaryCriteria<TItem> : Criteria<TItem>
	{
		protected Criteria<TItem> criteria1;
		protected Criteria<TItem> criteria2;

		public BinaryCriteria(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
		{
			this.criteria1 = criteria1;
			this.criteria2 = criteria2;
		}

		public abstract bool IsSatisfiedBy(TItem pet);
	}
}