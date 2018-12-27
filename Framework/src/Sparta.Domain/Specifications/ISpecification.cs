namespace Sparta.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entry);
    }
}
