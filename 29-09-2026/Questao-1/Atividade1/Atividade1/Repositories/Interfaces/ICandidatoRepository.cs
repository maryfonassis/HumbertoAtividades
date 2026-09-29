using Atividade1.Models;

namespace Atividade1.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        List<Candidato> Listar();

        bool Adicionar(Candidato candidato);

        Candidato? BuscarPorNumero(int numero);
    }
}
