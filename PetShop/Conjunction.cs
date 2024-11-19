namespace Training.DomainClasses;

// Composite (kompozyt)

public abstract class BinaryCriteria<TItem> : Criteria<TItem>
{
    protected readonly Criteria<TItem> _criteria1;
    protected readonly Criteria<TItem> _criteria2;
    public abstract bool IsSatisfiedBy(TItem item);

    public BinaryCriteria(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }
}

public class Conjunction<TItem>(Criteria<TItem> criteria1, Criteria<TItem> criteria2) : BinaryCriteria<TItem>(criteria1, criteria2)
{
    public override bool IsSatisfiedBy(TItem item)
    {
        return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
    }
}