using FluentValidation;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.Service.Services;

public abstract class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> _baseRepository;

    public BaseService(IBaseRepository<TEntity> baseRepository) =>
        _baseRepository = baseRepository;

    public async Task<TEntity> AddAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
    {
        await ValidateAsync(obj, Activator.CreateInstance<TValidator>());
        await _baseRepository.InsertAsync(obj);
        return obj;
    }

    public async Task DeleteAsync(Guid id) => await _baseRepository.DeleteAsync(id);

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _baseRepository.FindAllAsync();

    public async Task<TEntity> GetByIdAsync(Guid id) => await _baseRepository.FindByIdAsync(id);

    public async Task<TEntity> GetByPredicateAsync(Predicate<TEntity> predicate) => await this._baseRepository.FindByPredicateAsync(predicate);

    public async Task<TEntity> UpdateAsync<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
    {
        await ValidateAsync(obj, Activator.CreateInstance<TValidator>());
        await _baseRepository.UpdateAsync(obj);
        return obj;
    }

    private async Task ValidateAsync(TEntity obj, AbstractValidator<TEntity> validator)
    {
        if (obj == null)
            throw new Exception("Registros não detectados!");

        await validator.ValidateAndThrowAsync(obj);
    }

    ~BaseService() => Dispose();

    public void Dispose() => GC.SuppressFinalize(this);
}