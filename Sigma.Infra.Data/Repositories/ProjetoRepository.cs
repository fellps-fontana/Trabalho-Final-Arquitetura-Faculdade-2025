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

        public async Task<List<Projeto>> BuscarTodos()
        {
            return await _dbContext.Projetos.ToListAsync();
        }
        public async Task<List<Projeto>> BuscarPeloIdEStatus(int id, StatusProjeto? status)
        {
            var query = _dbContext.Projetos.AsQueryable();
            if (id > 0)
            {
                query = query.Where(p => p.Id == id);
            }
            if (status.HasValue)
            {
                query = query.Where(p => p.Status == status.Value);
            }
            return await query.ToListAsync();
        }
    }
}
