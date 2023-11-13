using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Domain.DTO;

public class SeguroDTO : BaseDTO
{
    public VeiculoEntity Veiculo { get; }
    public SeguradoraEntity Seguradora { get; }
    public SeguradoEntity Segurado { get; }
    public decimal PremioComercial { get; }
}
