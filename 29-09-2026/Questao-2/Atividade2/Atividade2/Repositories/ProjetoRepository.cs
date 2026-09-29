using Atividade2.Models;
using Atividade2.Repositories.Interfaces;

namespace Atividade2.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly List<Projeto> projetos = new();

        public List<Projeto> Listar()
        {
            return projetos;
        }

        public bool Adicionar(Projeto projeto)
        {
            if (projetos.Any(p => p.Numero == projeto.Numero))
            {
                return false;
            }

            projetos.Add(projeto);

            return true;
        }

        public Projeto? BuscarPorNumero(int numero)
        {
            return projetos.FirstOrDefault(p => p.Numero == numero);
        }
    }
}
