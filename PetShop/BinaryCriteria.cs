public abstract class BinaryCriteria<TItem> : Criteria<TItem>
{
	protected Criteria<TItem> _criteria;
	protected Criteria<TItem> _criteria2;

	public BinaryCriteria(Criteria<TItem> criteria, Criteria<TItem> criteria2)
	{
		_criteria = criteria;
		_criteria2 = criteria2;
	}

	public abstract bool IsSatisfiedBy(TItem item);
}