namespace PetShop;

public interface ICriteria<T>
{
    bool IsSatisfiedBy(T item);
}