namespace Teste.Seguro.Domain.Entity;

public class VeiculoEntity : BaseEntity
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal Valor { get; set; }

    //public Guid? SeguroId { get; set; }
    //public SeguroEntity? Seguro { get; set; }

    public VeiculoEntity()
    {
        Id = Guid.NewGuid();
    }
}
