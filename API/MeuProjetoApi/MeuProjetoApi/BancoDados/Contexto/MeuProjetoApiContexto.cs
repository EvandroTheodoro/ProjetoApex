using MeuProjetoApi.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalApi.BancoDados.Config;
using ProjetoFinalApi.Models;

namespace MeuProjetoApi.BancoDados.Contexto
{
    public class MeuProjetoApiContexto : DbContext
    {
        public DbSet<Pessoa> TabelaPessoas { get; set; }
        public DbSet<Projetos> TabelaProjetos { get; set; }

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
            modelBuilder.ApplyConfiguration(new ProjetosConfig()); 
        }
    }
}
