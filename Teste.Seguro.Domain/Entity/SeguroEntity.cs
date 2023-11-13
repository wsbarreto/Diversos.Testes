namespace Teste.Seguro.Domain.Entity;

public class SeguroEntity : BaseEntity
{
    public Guid SeguradoraId { get; private set; }
    public Guid VeiculoId { get; private set; }
    public Guid SeguradoId { get; private set; }
    public virtual SeguradoraEntity Seguradora { get; set; }
    public virtual VeiculoEntity Veiculo { get; set; }
    public virtual SeguradoEntity Segurado { get; set; }
    public decimal ValorFinal { get; private set; }

    public SeguroEntity(Guid seguradoraId, Guid veiculoId, Guid seguradoId, decimal valorFinal)
    {
        this.Id = Guid.NewGuid();
        this.SeguradoraId = seguradoraId;
        this.VeiculoId = veiculoId;
        this.SeguradoId = seguradoId;
        this.ValorFinal = valorFinal;
    }
}
