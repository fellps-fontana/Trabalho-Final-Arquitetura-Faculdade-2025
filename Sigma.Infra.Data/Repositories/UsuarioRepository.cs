using Microsoft.EntityFrameworkCore;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sigma.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SigmaContext _dbContext;

        public UsuarioRepository(SigmaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Inserir(Usuario entidade)
        {
            await _dbContext.Set<Usuario>().AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Atualizar(Usuario entidade)
        {
            _dbContext.Set<Usuario>().Update(entidade);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Usuario>> BuscarTodos()
        {
            return await _dbContext.Set<Usuario>().ToListAsync();
        }

        public async Task<Usuario> BuscarPeloId(int id)
        {
            return await _dbContext.Set<Usuario>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> BuscarPeloUsername(string Nome)
        {
            return await _dbContext.Set<Usuario>().FirstOrDefaultAsync(u => u.Nome == Nome);
        }

        public async Task<bool> Deletar(Usuario usuarioExcluir)
        {
            _dbContext.Set<Usuario>().Remove(usuarioExcluir);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
