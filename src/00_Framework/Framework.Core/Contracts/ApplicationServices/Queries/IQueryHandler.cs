using Framework.Core.RequestResponse.Queries;

namespace Framework.Core.Contracts.ApplicationServices.Queries;

public interface IQueryHandler<TQuery, TData>
  where TQuery : class, IQuery<TData>
{
    Task<QueryResult<TData>> Handle(TQuery request);
}
