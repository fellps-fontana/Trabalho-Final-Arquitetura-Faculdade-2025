using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoNovoDto model);
        Task<List<Projeto>> BuscarTodos();
    }
}
