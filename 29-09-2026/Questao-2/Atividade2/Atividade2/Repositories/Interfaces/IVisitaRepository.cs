using Atividade2.Models;

namespace Atividade2.Repositories.Interfaces
{
    public interface IVisitaRepository
    {
        void Adicionar(Visita visita);

        List<Visita> ListarPorProjeto(int numeroProjeto);
    }
}
