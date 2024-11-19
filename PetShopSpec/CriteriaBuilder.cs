using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
	public class CriteriaBuilder
	{
		private Func<Pet, Species> propertySelector;
		public CriteriaBuilder(Func<Pet, Species> propertySelector)
		{
			this.propertySelector = propertySelector;
		}
		public Criteria<Pet> EqualTo(Species species)
		{
			return new AnonymousCriteria<Pet>(pet => propertySelector(pet) == species);
		}
	}
}