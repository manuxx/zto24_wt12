using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        private IEnumerable<TItem> pets;
        public ReadOnlySet(IEnumerable<TItem> pets)
        {
            this.pets = pets;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return pets.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}