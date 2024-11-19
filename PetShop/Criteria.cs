using System.Collections.Concurrent;

public interface Criteria<T>
{
	bool IsSatisfiedBy(T item);
}