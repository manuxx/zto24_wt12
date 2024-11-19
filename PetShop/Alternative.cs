namespace Training.DomainClasses
{
	internal class Alternative<TItem> : Criteria<TItem>
	{
		Criteria<TItem> _criteria1;
		Criteria<TItem> _criteria2;

		public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
		{
			_criteria1 = criteria1;
			_criteria2 = criteria2;
		}

		public bool IsSatisfiedBy(TItem pet)
		{
			return _criteria1.IsSatisfiedBy(pet) || _criteria2.IsSatisfiedBy(pet);
		}
	}
}