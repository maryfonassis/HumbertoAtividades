using Atividade1.Models;
using Atividade1.Repositories.Interfaces;

namespace Atividade1.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly List<Candidato> candidatos = new();

        public List<Candidato> Listar()
        {
            return candidatos;
        }

        public bool Adicionar(Candidato candidato)
        {
            if (candidatos.Any(c => c.Numero == candidato.Numero))
            {
                return false;
            }

            candidatos.Add(candidato);
            return true;
        }

        public Candidato? BuscarPorNumero(int numero)
        {
            return candidatos.FirstOrDefault(c => c.Numero == numero);
        }
    }
}
