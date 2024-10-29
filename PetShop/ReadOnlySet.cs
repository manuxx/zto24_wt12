using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        private readonly IList<TItem> _petsInTheStore;

        public ReadOnlySet(IList<TItem> petsInTheStore)
        {
            _petsInTheStore = petsInTheStore;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return _petsInTheStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}