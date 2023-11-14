using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Data.Mapping;

public class SeguradoraMapping : IEntityTypeConfiguration<SeguradoraEntity>
{
    public void Configure(EntityTypeBuilder<SeguradoraEntity> builder)
    {
        builder.ToTable("TB_SEGURADORA");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Nome)
            .HasConversion(w => ((string)w), w => w)
            .HasColumnName("NOME")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(w => w.MargemSeguranca)
            .HasConversion(w => ((decimal)w), w => w)
            .HasColumnName("MARGEM_SEGURANCA")
            .HasColumnType("DECIMAL")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(w => w.Lucro)
            .HasConversion(w => ((decimal)w), w => w)
            .HasColumnName("LUCRO")
            .HasColumnType("DECIMAL")
            .HasPrecision(18, 2)
            .IsRequired();
    }
}
