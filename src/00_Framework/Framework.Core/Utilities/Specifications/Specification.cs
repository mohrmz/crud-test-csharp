namespace Framework.Core.Utilities.Specifications;

public static class SpecificationExtensions
{
    public static ISpecification<TEnitity> And<TEnitity>(this ISpecification<TEnitity> left,
                                                         ISpecification<TEnitity> right)
    {
        return new AndSpecification<TEnitity>(left, right);
    }

    public static ISpecification<TEnitity> Or<TEnitity>(this ISpecification<TEnitity> left,
                                                     ISpecification<TEnitity> right)
    {
        return new OrSpecification<TEnitity>(left, right);
    }

    public static ISpecification<TEnitity> Not<TEnitity>(this ISpecification<TEnitity> specification)
    {
        return new NotSpecification<TEnitity>(specification);
    }
}

public class AndSpecification<TEnitity> : ISpecification<TEnitity>
{
    private readonly ISpecification<TEnitity> _left;
    private readonly ISpecification<TEnitity> _right;

    public AndSpecification(ISpecification<TEnitity> left, ISpecification<TEnitity> right)
    {
        _left = left;
        _right = right;
    }

    public bool IsSatisfiedBy(TEnitity enitity)
    {
        return _left.IsSatisfiedBy(enitity) && _right.IsSatisfiedBy(enitity);
    }
}

public class OrSpecification<TEnitity> : ISpecification<TEnitity>
{
    private readonly ISpecification<TEnitity> _left;
    private readonly ISpecification<TEnitity> _right;

    public OrSpecification(ISpecification<TEnitity> left, ISpecification<TEnitity> right)
    {
        _left = left;
        _right = right;
    }

    public bool IsSatisfiedBy(TEnitity enitity)
    {
        return _left.IsSatisfiedBy(enitity) || _right.IsSatisfiedBy(enitity);
    }
}


public class NotSpecification<TEnitity> : ISpecification<TEnitity>
{
    private readonly ISpecification<TEnitity> _specification;

    public NotSpecification(ISpecification<TEnitity> specification)
    {
        _specification = specification;
    }

    public bool IsSatisfiedBy(TEnitity enitity)
    {
        return !_specification.IsSatisfiedBy(enitity);
    }
}


