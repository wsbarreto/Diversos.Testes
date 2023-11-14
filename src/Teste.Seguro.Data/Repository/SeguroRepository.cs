using Teste.Seguro.Data.Context;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;

namespace Teste.Seguro.Data.Repository;

public class SeguroRepository : BaseRepository<SeguroEntity>, ISeguroRepository
{
    private readonly DataContext _dataContext;
    public SeguroRepository(DataContext dataContext) : base(dataContext) =>
        this._dataContext = dataContext;
}
