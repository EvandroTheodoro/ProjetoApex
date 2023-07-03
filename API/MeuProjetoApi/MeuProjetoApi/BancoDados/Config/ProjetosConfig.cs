using MeuProjetoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFinalApi.Models;

namespace ProjetoFinalApi.BancoDados.Config
{
    public class ProjetosConfig : IEntityTypeConfiguration<Projetos>
    {
        public void Configure(EntityTypeBuilder<Projetos> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();

            //mapeando as propriedades

            builder.Property(x => x.NomeCliente)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.Tensao)
               .IsRequired();


            builder.Property(x => x.Potencia)
               .IsRequired();


            builder.Property(x => x.QntBobinas)
               .IsRequired();


            builder.Property(x => x.ValorProjeto);
               

        }

    }

}

