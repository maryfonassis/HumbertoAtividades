using Atividade2.Models;
using Atividade2.Repositories.Interfaces;

namespace Atividade2.Repositories
{
    public class VisitaRepository : IVisitaRepository
    {
        private readonly List<Visita> visitas = new();

        public void Adicionar(Visita visita)
        {
            visitas.Add(visita);
        }

        public List<Visita> ListarPorProjeto(int numeroProjeto)
        {
            return visitas
                .Where(v => v.NumeroProjeto == numeroProjeto)
                .ToList();
        }
    }
}
