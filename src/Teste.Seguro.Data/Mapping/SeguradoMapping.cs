using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Data.Mapping
{
    public class SeguradoMapping : IEntityTypeConfiguration<SeguradoEntity>
    {
        public void Configure(EntityTypeBuilder<SeguradoEntity> builder)
        {
            builder.ToTable("TB_SEGURADO");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Nome)
                .HasConversion(w => ((string)w), w => w)
                .HasColumnName("NOME")
            .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(w => w.CPF)
               .HasConversion(w => ((string)w), w => w)
               .HasColumnName("CPF")
            .HasColumnType("NVARCHAR")
               .HasMaxLength(14)
               .IsRequired();
        }
    }
}
