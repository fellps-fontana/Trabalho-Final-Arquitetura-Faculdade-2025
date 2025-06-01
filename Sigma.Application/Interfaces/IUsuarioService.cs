using Sigma.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sigma.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Inserir(UsuarioDto usuarioDto);
        Task<bool> Atualizar(int id, UsuarioDto usuarioDto);
        Task<List<UsuarioDto>> BuscarTodos();
        Task<UsuarioDto> BuscarPeloId(int id);
        Task<UsuarioDto> BuscarPeloNome(string nome);
        Task<bool> Deletar(int id);
    }
}
