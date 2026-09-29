using Atividade1.Models;
using Atividade1.Repositories.Interfaces;

namespace Atividade1.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly List<Voto> votos = new();

        public void Adicionar(Voto voto)
        {
            votos.Add(voto);
        }

        public List<Voto> ListarPorCandidato(int numeroCandidato)
        {
            return votos
                .Where(v => v.NumeroCandidato == numeroCandidato)
                .ToList();
        }
    }
}
