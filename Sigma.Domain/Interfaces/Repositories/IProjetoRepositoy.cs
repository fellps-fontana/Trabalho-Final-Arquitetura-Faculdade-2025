using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> Inserir(Projeto entidade);
        Task<Projeto> BuscarPeloId (int id);
        Task<List<Projeto>> BuscarTodos();
        Task<List<Projeto>> BuscarPeloStatus(StatusProjeto status );
        Task<bool> Atualizar(Projeto entidade);
        Task<bool> Deletar(Projeto projetoExcluir);
    }
}
