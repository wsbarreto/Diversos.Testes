using Teste.Seguro.Data.Context;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;

namespace Teste.Seguro.Data.Repository;

public class SeguradoraRepository : BaseRepository<SeguradoraEntity>, ISeguradoraRepository
{
    private readonly DataContext _dataContext;
    public SeguradoraRepository(DataContext dataContext) : base(dataContext) =>
        this._dataContext = dataContext;
}