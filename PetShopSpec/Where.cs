using System;
using Training.DomainClasses;

namespace Training.Specificaton
{
	public class Where<T>
	{
		public Where()
		{

		}

		public static CriteriaBuilder HasAn(Func<Pet, Species> func)
		{
			return new CriteriaBuilder(func);
		}
	}
}