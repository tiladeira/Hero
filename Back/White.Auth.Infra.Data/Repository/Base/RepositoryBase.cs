using Microsoft.EntityFrameworkCore;

using White.Auth.Core.Entities.Base;
using White.Auth.Core.Interfaces.Base;
using White.Auth.Infra.Data.Context;

namespace White.Auth.Infra.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public readonly AppDbContext _appDbContext;

        public RepositoryBase(AppDbContext appContext)
        {
            _appDbContext = appContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task DeleteByAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }
    }
}
