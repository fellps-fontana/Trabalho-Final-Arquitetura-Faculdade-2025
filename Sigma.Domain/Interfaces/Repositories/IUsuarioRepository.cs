using Sigma.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> Inserir(Usuario entidade);
        Task<bool> Atualizar(Usuario entidade);
        Task<List<Usuario>> BuscarTodos();
        Task<Usuario> BuscarPeloId(int id);
        Task<Usuario> BuscarPeloUsername(string username);
        Task<bool> Deletar(Usuario entidade);
    }
}
