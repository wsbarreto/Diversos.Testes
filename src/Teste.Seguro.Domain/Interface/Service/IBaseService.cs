using FluentValidation;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Domain.Interface.Service;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    Task<TEntity> UpdateAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    Task DeleteAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByPredicateAsync(Predicate<TEntity> predicate);
    Task<TEntity> GetByIdAsync(Guid id);
}
