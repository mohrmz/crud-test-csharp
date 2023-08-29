namespace Framework.Endpoints.AutoMapper.Contracts;

public interface IMapperAdapter
{
    TDestination Map<TSource, TDestination>(TSource source);
}
