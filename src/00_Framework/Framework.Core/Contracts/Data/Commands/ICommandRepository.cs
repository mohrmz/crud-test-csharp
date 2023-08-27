using Framework.Core.Domain.Entities;

namespace Framework.Core.Contracts.Data.Commands;

public interface ICommandRepository<TEntity, TId> : IUnitOfWork 
 where TEntity : AggregateRoot<TId>
  where TId : struct,
       IComparable,
       IComparable<TId>,
       IConvertible,
       IEquatable<TId>,
       IFormattable
{
    void Delete(TId id);
    void DeleteGraph(TId id);
    void Delete(TEntity entity);
    void Insert(TEntity entity);
    Task InsertAsync(TEntity entity);

}
