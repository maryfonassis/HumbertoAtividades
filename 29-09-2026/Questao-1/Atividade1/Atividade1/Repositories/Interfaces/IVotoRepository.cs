using Atividade1.Models;

namespace Atividade1.Repositories.Interfaces
{
    public interface IVotoRepository
    {
        void Adicionar(Voto voto);

        List<Voto> ListarPorCandidato(int numeroCandidato);
    }
}
