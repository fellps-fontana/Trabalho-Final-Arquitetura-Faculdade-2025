using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoDto model);
        Task<List<ProjetoDto>> BuscarTodos();
        Task<List<ProjetoDto>> BuscarPeloStatus(StatusProjeto status);
        Task<ProjetoDto?> BuscarPeloId(int id);

        Task<bool> Atualizar(int id, ProjetoDtoAtualizacao model);
        Task<bool> Deletar(int id);
    }
} 
