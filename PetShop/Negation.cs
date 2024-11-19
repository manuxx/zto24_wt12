namespace Training.DomainClasses;

// Decorator

public class Negation<TItem>(Criteria<TItem> criteria) : Criteria<TItem>
{
    public bool IsSatisfiedBy(TItem item)
    {
        return !criteria.IsSatisfiedBy(item);
    }
}