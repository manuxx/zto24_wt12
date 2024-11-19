public class Conjunction<TItem> : BinaryCriteria<TItem>
{
	public Conjunction(Criteria<TItem> criteria, Criteria<TItem> criteria2) : base(criteria, criteria2)
	{
	}

	public override bool IsSatisfiedBy(TItem item)
	{
		return _criteria.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
	}
}