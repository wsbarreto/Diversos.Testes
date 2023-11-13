using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Data.Mapping;

public class VeiculoMapping : IEntityTypeConfiguration<VeiculoEntity>
{
    public void Configure(EntityTypeBuilder<VeiculoEntity> builder)
    {
        builder.ToTable("TB_VEICULO");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Marca)
                .HasConversion(w => ((string)w), w => w)
                .HasMaxLength(50)
                .IsRequired();

        builder.Property(w => w.Modelo)
                .HasConversion(w => ((string)w), w => w)
                .HasMaxLength(50)
                .IsRequired();

        builder.Property(w => w.Valor)
                .HasConversion(w => ((decimal)w), w => w)
                .HasPrecision(18, 2)
                .IsRequired();
    }
}
