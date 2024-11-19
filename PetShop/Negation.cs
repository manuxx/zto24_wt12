namespace Training.DomainClasses;

public class Negation : Criteria<Pet>
{
	private Criteria<Pet> _criteria;

	public Negation(Criteria<Pet> criteria)
	{
		_criteria = criteria;
	}

	public bool IsSatisfiedBy(Pet pet)
	{
		return !_criteria.IsSatisfiedBy(pet);
	}
}