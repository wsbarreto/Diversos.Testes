using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.Service.Services;

public class SeguradoraService : BaseService<SeguradoraEntity>, ISeguradoraService
{
    private readonly ISeguradoraRepository _repository;
    public SeguradoraService(ISeguradoraRepository repository) : base(repository) =>
        this._repository = repository;
}
