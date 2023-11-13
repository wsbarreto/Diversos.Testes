using Dapper;
using System.Data;
using System.Data.Common;
using Teste.Seguro.Data.Context;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;

namespace Teste.Seguro.Data.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DataContext _dataContext;

    public BaseRepository(DataContext dataContext) =>
        _dataContext = dataContext;

    public async Task InsertAsync(TEntity entity)
    {
        try
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        catch (DataException ex) { throw (ex); }
        catch (DbException ex) { throw (ex); }
        catch (Exception ex) { throw (ex); }
    }

    public async Task UpdateAsync(TEntity entity)
    {
        try
        {
            _dataContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
        catch (DataException ex) { throw (ex); }
        catch (DbException ex) { throw (ex); }
        catch (Exception ex) { throw (ex); }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var entity = await FindByIdAsync(id);

            if (entity == null)
                return;

            _dataContext.Set<TEntity>().Remove(entity);
            _dataContext.SaveChanges();
        }
        catch (DataException ex) { throw(ex); }
        catch (DbException ex) { throw(ex); }
        catch (Exception ex) { throw(ex); }
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync()
    {
        try
        {
            var www = _dataContext.Set<TEntity>().ToList();
            return www;
        }
        catch (DataException ex) { throw (ex); }
        catch (DbException ex) { throw (ex); }
        catch (Exception ex) { throw (ex); }
    }

    public async Task<TEntity> FindByIdAsync(Guid id)
    {
        try
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }
        catch (DataException ex) { throw (ex); }
        catch (DbException ex) { throw (ex); }
        catch (Exception ex) { throw (ex); } 
    }

    public async Task<TEntity> FindByPredicateAsync(Predicate<TEntity> predicate)
    {
        try
        {
            return await _dataContext.Set<TEntity>().FindAsync(predicate);
        }
        catch (DataException ex) { throw (ex); }
        catch (DbException ex) { throw (ex); }
        catch (Exception ex) { throw (ex); } 
    }

}
