using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> Inserir(Projeto entidade);

        Task<List<Projeto>> BuscarTodos();
        Task<List<Projeto>> BuscarPeloIdEStatus(int id, StatusProjeto? status = null);

    }
}
