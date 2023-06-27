using MeuProjetoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoApi.BancoDados.Contexto
{
    public class MeuProjetoApiContexto : DbContext
    {
        public DbSet<Pessoa> TabelaPessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=DESKTOP-F0EGQ2L\\SQLEXPRESS;Database=MeuProjetoApi;User Id=sa;Password=123456789;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Config.PessoaConfig());
        }
    }
}
