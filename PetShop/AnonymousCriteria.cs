using System;
using PetShop;

public class AnonymousCriteria<T> : ICriteria<T>
{
    private readonly Predicate<T>[] _conjunction;

    public AnonymousCriteria(Predicate<T>[] conjunction)
    {
        _conjunction = conjunction;
    }

    public bool IsSatisfiedBy(T item)
    {
        foreach (var condition in _conjunction)
        {
            if (!condition(item))
                return false;
        }

        return true;
    }
}