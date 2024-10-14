using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // Definindo DbSet corretamente para Fornecedores e Vendedores
        public DbSet<FornecedorEntity> Fornecedores { get; set; }
        public DbSet<VendedorEntity> Vendedores { get; set; }

        // Configurações adicionais do modelo (se necessário)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemplo de configuração adicional (opcional)
            // modelBuilder.Entity<FornecedorEntity>().HasKey(f => f.Id);
            // modelBuilder.Entity<VendedorEntity>().HasKey(v => v.Id);
        }
    }
}
