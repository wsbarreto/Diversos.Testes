using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Domain.Interface.Service;
public interface ISeguroService : IBaseService<SeguroEntity>
{
    Task<SeguroEntity> CalcularSeguroAsync(SeguroEntity seguro);
}
