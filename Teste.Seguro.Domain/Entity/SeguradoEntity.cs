namespace Teste.Seguro.Domain.Entity;

public class SeguradoEntity : BaseEntity
{
    public string Nome { get; set; }
    public string CPF { get; set; }

    //public Guid? SeguroId { get; set; }
    //public SeguroEntity? Seguro { get; set; }

    public SeguradoEntity()
    {
        Id = Guid.NewGuid();
    }
}
