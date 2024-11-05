using System;
using PetShop;

public class AnonymousCriteria<T> : ICriteria<T>
{
    private readonly Predicate<T>[] _conditions;

    public AnonymousCriteria(Predicate<T>[] conditions)
    {
        _conditions = conditions;
    }

    public bool IsSatisfiedBy(T item)
    {
        foreach (var condition in _conditions)
        {
            if (!condition(item))
                return false;
        }

        return true;
    }
}