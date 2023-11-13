using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.Service.Services;

public class VeiculoService : BaseService<VeiculoEntity>, IVeiculoService
{
    private readonly IVeiculoRepository _repository;
    public VeiculoService(IVeiculoRepository repository) : base(repository) =>
        this._repository = repository;


}
