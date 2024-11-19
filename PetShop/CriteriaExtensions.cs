using Training.DomainClasses;

public static class CriteriaExtensions
{
	public static Alternative<TItem> Or<TItem>(this Criteria<TItem> criteria, Criteria<TItem> criteria2)
	{
		return new Alternative<TItem>(criteria, criteria2);
	}

	public static Conjunction<TItem> And<TItem>(this Criteria<TItem> criteria, Criteria<TItem> criteria2)
	{
		return new Conjunction<TItem>(criteria, criteria2);
	}
}