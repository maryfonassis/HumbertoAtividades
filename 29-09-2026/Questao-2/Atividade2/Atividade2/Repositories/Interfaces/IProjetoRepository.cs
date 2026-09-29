using Atividade2.Models;

namespace Atividade2.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        List<Projeto> Listar();

        bool Adicionar(Projeto projeto);

        Projeto? BuscarPorNumero(int numero);
    }
}

