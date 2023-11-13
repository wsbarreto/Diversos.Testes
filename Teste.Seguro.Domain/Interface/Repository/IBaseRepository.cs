using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Domain.Interface.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(Guid id);

    Task<IEnumerable<TEntity>> FindAllAsync();

    Task<TEntity> FindByIdAsync(Guid id);

    Task<TEntity> FindByPredicateAsync(Predicate<TEntity> predicate);
}