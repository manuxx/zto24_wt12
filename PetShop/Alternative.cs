namespace Training.DomainClasses;

// Composite (kompozyt)

public class Alternative<TItem>(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : BinaryCriteria<TItem>(criteria1, criteria2)
{
    public override bool IsSatisfiedBy(TItem item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}