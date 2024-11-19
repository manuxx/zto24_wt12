using System.Runtime.CompilerServices;

namespace Training.DomainClasses;

public class Conjunction : Criteria<Pet>
{
	private readonly Criteria<Pet> _criteria1;
	private readonly Criteria<Pet> _criteria2;

	public Conjunction(Criteria<Pet> criteria1, Criteria<Pet> criteria2)
	{
		_criteria1 = criteria1;
		_criteria2 = criteria2;
	}

	public bool IsSatisfiedBy(Pet pet)
	{
		return _criteria1.IsSatisfiedBy(pet) && _criteria2.IsSatisfiedBy(pet);
	}
}
