using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Teste.Seguro.Domain.Entity;

namespace Teste.Seguro.Data.Context
{
    public class DataContext : DbContext
    {
        private readonly string connectionString = WebApplication.CreateBuilder().Configuration.GetSection("ConnectionStrings")["connectionString"];

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

        public DataContext CreateDbContext() =>
            new DataContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);

        public DataContext(DbContextOptions options) : base(options)
        {
            var www = options.Extensions;
        }

        public DbSet<SeguradoEntity> Segurados { get; set; }
        public DbSet<SeguradoraEntity> Seguradoras { get; set; }
        public DbSet<SeguroEntity> Seguros { get; set; }
        public DbSet<VeiculoEntity> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("SEGURO");

            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            var mappingTypes = typeof(DataContext).GetTypeInfo().Assembly.GetTypes()
                .Where(w => w.GetInterfaces().Any(b => b.GetTypeInfo().IsGenericType && b.GetGenericTypeDefinition() == mappingInterface));

            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(w => w.Name == "Entity" &&
                        w.IsGenericMethod &&
                        w.ReturnType.Name == "EntityTypeBuilder`1");

            mappingTypes.ToList().ForEach((item) =>
            {
                var genericTypeArguments = item.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArguments);
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);

                var mapper = Activator.CreateInstance(item);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
            });

            #region mapping

            //modelBuilder.Entity<SeguroEntity>()
            //    .HasOne<SeguradoEntity>(w => w.Segurado)
            //    .WithOne(w => w.Seguro)
            //    .HasForeignKey<SeguradoEntity>(w => w.SeguroId);

            //modelBuilder.Entity<SeguroEntity>()
            //    .HasOne<VeiculoEntity>(w => w.Veiculo)
            //    .WithOne(w => w.Seguro)
            //    .HasForeignKey<VeiculoEntity>(w => w.SeguroId);

            //modelBuilder.Entity<SeguroEntity>()
            //    .HasOne<SeguradoraEntity>(w => w.Seguradora)
            //    .WithOne(w => w.Seguro)
            //    .HasForeignKey<SeguradoraEntity>(w => w.SeguroId);

            #endregion

        }

    }
}