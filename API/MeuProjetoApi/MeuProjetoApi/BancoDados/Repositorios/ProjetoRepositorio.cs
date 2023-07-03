using MeuProjetoApi.BancoDados.Contexto;
using MeuProjetoApi.Models;
using ProjetoFinalApi.Models;

namespace ProjetoFinalApi.BancoDados.Repositorios
{
    public class ProjetoRepositorio
    {
        public Projetos Adicionar(Projetos projeto)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                bancoDeDados.TabelaProjetos.Add(projeto);
                bancoDeDados.SaveChanges();
            }

            return projeto;
        }

        public Projetos Atualizar(Projetos projeto)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                bancoDeDados.TabelaProjetos.Update(projeto);
                bancoDeDados.SaveChanges();
            }

            return projeto;
        }

        public void Excluir(int id)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                var projeto = bancoDeDados.TabelaProjetos
                    .Where(projeto => projeto.Id == id)
                    .FirstOrDefault();

                if (projeto != null)
                {
                    bancoDeDados.Remove(projeto);
                    bancoDeDados.SaveChanges();
                }
            }
        }

        public Projetos ObterPorId(int id)
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                var projeto = bancoDeDados.TabelaProjetos
                    .Where(projeto => projeto.Id == id)
                    .FirstOrDefault();

                return projeto;
            }
        }

        public List<Projetos> ObterTodos()
        {
            using (var bancoDeDados = new MeuProjetoApiContexto())
            {
                var listaProjetos = bancoDeDados.TabelaProjetos.ToList();
                return listaProjetos;
            }
        }
    }
}
