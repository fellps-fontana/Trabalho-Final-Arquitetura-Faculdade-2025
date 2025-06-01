using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;

namespace Sigma.Infra.Data.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly SigmaContext _dbContext;

        public ProjetoRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Inserir(Projeto entidade)
        {
            if (entidade.DataRealTermino.HasValue)
            {
                entidade.DataRealTermino = entidade.DataRealTermino.Value.ToUniversalTime();
            }
            if (entidade.PrevisaoTermino.HasValue)
            {
                entidade.PrevisaoTermino = entidade.PrevisaoTermino.Value.ToUniversalTime();
            }
            entidade.DataInicio = entidade.DataInicio.ToUniversalTime();
            await _dbContext.Set<Projeto>().AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
            return true;

        }
        public async Task<bool> Atualizar(Projeto entidade)
        {
            if (entidade.DataRealTermino.HasValue)
            {
                entidade.DataRealTermino = entidade.DataRealTermino.Value.ToUniversalTime();
            }
            if (entidade.PrevisaoTermino.HasValue)
            {
                entidade.PrevisaoTermino = entidade.PrevisaoTermino.Value.ToUniversalTime();
            }
            entidade.DataInicio = entidade.DataInicio.ToUniversalTime();

            _dbContext.Set<Projeto>().Update(entidade);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Projeto>> BuscarTodos()
        {
            return await _dbContext.Projetos.ToListAsync();
        }
        public async Task<Projeto>BuscarPeloId(int id)
        {
            return await _dbContext.Projetos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Projeto>> BuscarPeloStatus(StatusProjeto status)
        {
            return await _dbContext.Projetos.Where(p => p.Status == status).ToListAsync();
        }

        public async Task<bool> Deletar (Projeto projetoExcluir)
        {
            await _dbContext.Projetos
                .Where(p => p.Id == projetoExcluir.Id)
                .ExecuteDeleteAsync();

            return true;
        }

    }
 
}
