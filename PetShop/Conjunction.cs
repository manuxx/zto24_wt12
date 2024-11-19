namespace Training.DomainClasses
{
	internal class Conjunction<TItem> : Criteria<TItem>
	{
		private Criteria<TItem> _criteria1;
		private Criteria<TItem> _criteria2;

		public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
		{
			_criteria1 = criteria1;
			_criteria2 = criteria2;
		}

		public bool IsSatisfiedBy(TItem pet)
		{
			return _criteria1.IsSatisfiedBy(pet) && _criteria2.IsSatisfiedBy(pet);
		}
	}
}