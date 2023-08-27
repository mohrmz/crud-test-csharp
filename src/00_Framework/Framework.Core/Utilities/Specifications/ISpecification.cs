namespace Framework.Core.Utilities.Specifications;

public interface ISpecification<TEnitity>
{
    bool IsSatisfiedBy(TEnitity enitity);
}


