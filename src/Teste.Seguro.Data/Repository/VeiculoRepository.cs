using Teste.Seguro.Data.Context;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;

namespace Teste.Seguro.Data.Repository;

public class VeiculoRepository : BaseRepository<VeiculoEntity>, IVeiculoRepository
{
    private readonly DataContext _dataContext;
    public VeiculoRepository(DataContext dataContext) : base(dataContext) =>
        this._dataContext = dataContext;
}