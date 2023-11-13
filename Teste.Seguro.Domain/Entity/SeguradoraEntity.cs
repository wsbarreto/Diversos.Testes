namespace Teste.Seguro.Domain.Entity;

public class SeguradoraEntity : BaseEntity
{
    public string Nome { get; set; }
    public decimal MargemSeguranca { get; set; }
    public decimal Lucro { get; set; }

    //public Guid? SeguroId { get; set; }
    //public SeguroEntity? Seguro { get; set; }

    public SeguradoraEntity()
    {
        Id = Guid.NewGuid();
    }
}
