using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Alternative<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> isSpeciesOf)
    {
        return new Alternative<TItem>(criteria1,isSpeciesOf);
    }

    public static Conjunction<Pet> And<Pet>(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Conjunction<Pet>(criteria1,criteria2);
    }
}