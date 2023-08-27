using Framework.Core.Contracts.Data.Queries;
using Framework.Core.Domain.Entities;
using Framework.Core.Domain.ValueObjects;
using System.Linq.Expressions;

namespace Framework.Infrastructures.Data.Queries;

public class BaseQueryRepository<TEntity, TDbContext, TId> : IQueryRepository<TEntity, TId>
    where TDbContext : BaseQueryDbContext
    where TEntity : AggregateRoot<TId>
     where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public int Commit()
    {
        throw new NotImplementedException();
    }

    public Task<int> CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public TEntity GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity GetGraph(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }
}