using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnlySet<TItem> : IEnumerable<TItem>
{
    private readonly IEnumerable<TItem> _pets;

    public ReadOnlySet(IEnumerable<TItem> pets)
    {
        _pets = pets;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        return _pets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}