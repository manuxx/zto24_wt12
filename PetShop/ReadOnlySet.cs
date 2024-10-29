using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        public ReadOnlySet(IEnumerable<TItem> pets)
        {
        }

        public IEnumerator<TItem> GetEnumerator()
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}