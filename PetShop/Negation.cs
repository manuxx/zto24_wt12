namespace Training.DomainClasses
{
	internal class Negation<TItem> : Criteria<TItem>
	{
		Criteria<TItem> _criteria;
		public Negation(Criteria<TItem> criteria)
		{
			_criteria = criteria;
		}

		public bool IsSatisfiedBy(TItem pet)
		{
			return !_criteria.IsSatisfiedBy(pet);
		}
	}
}