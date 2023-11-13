using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.Service.Services;

public class SeguradoService : BaseService<SeguradoEntity>, ISeguradoService
{
    private readonly ISeguradoRepository _repository;
    public SeguradoService(ISeguradoRepository repository) : base(repository) =>
        this._repository = repository;
}