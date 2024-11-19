using Training.DomainClasses;

public static class CriteriaExtensions
{
	public static Alternative<Pet> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
	{
		return new Alternative<Pet>(criteria1, isSpeciesOf);
	}

	public static Conjunction<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
	{
		return new Conjunction<TItem>(criteria1, criteria2);
	}
}