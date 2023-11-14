using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Data.Mapping
{
    public class SeguroMapping : IEntityTypeConfiguration<SeguroEntity>
    {
        public void Configure(EntityTypeBuilder<SeguroEntity> builder)
        {
            builder.ToTable("TB_SEGURO");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.SeguradoraId)
                .HasConversion(w => ((Guid)w), w => w)
                .HasColumnName("TB_SEGURADORA_ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            //builder.Property<SeguradoraEntity>(w => w.Seguradora)
            //    .IsRequired();

            builder.Property(w => w.VeiculoId)
                .HasConversion(w => ((Guid)w), w => w)
                .HasColumnName("TB_VEICULO_ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            //builder.Property<VeiculoEntity>(w => w.Veiculo)
            //    .IsRequired();

            builder.Property(w => w.SeguradoId)
                .HasConversion(w => ((Guid)w), w => w)
                .HasColumnName("TB_SEGURADO_ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            //builder.Property<SeguradoEntity>(w => w.Segurado)
            //    .IsRequired();

            builder.Property(w => w.ValorFinal)
                .HasConversion(w => ((decimal)w), w => w)
                .HasColumnName("VALOR_FINAL")
                .HasColumnType("DECIMAL")
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
