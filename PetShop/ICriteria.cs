using System;
using Training.DomainClasses;

public interface ICriteria<T>
{
    bool IsSatisfiedBy(T pet);

}