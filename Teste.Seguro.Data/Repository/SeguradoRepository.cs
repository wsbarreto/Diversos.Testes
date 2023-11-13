using Teste.Seguro.Data.Context;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;

namespace Teste.Seguro.Data.Repository;

public class SeguradoRepository : BaseRepository<SeguradoEntity>, ISeguradoRepository
{
    private readonly DataContext _dataContext;
    public SeguradoRepository(DataContext dataContext) : base(dataContext) =>
        this._dataContext = dataContext;
}