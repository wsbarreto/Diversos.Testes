using System.Globalization;
using Teste.Seguro.Domain.Entity;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;

namespace Teste.Seguro.Service.Services;

public class SeguroService : BaseService<SeguroEntity>, ISeguroService
{
    private readonly ISeguroRepository _repository;
    private readonly NumberFormatInfo setPrecision;

    public SeguroService(ISeguroRepository baseRepository) : base(baseRepository)
    {
        this._repository = baseRepository;
        setPrecision = new NumberFormatInfo();
        setPrecision.NumberDecimalDigits = 2;
    }

    public async Task<SeguroEntity> CalcularSeguroAsync(SeguroEntity seguro)
    {
        var taxaRisco = (decimal)(seguro.Veiculo.Valor * 5) / (seguro.Veiculo.Valor * 2);
        var premioRisco = (decimal)taxaRisco * seguro.Veiculo.Valor;
        var premioPuro = (decimal)premioRisco * (1 + seguro.Seguradora.MargemSeguranca);
        var premioComercial = (decimal)seguro.Seguradora.Lucro * premioPuro;

        return new SeguroEntity(seguro.Seguradora.Id, seguro.Veiculo.Id, seguro.SeguradoId, (premioComercial + premioPuro));
    }
}
