using Framework.Core.ApplicationServices.Queries;
using Framework.Core.RequestResponse.Queries;

namespace Mc2.CrudTest.Presentation.Server.Decorators;

public class QueryDecorator : QueryDispatcherDecorator
{
    public override int Order => 0;

    public override async Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query)
    {
        return await _queryDispatcher.Execute<TQuery, TData>(query);
    }
}
