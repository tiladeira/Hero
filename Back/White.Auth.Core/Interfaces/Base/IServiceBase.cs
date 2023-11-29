using White.Auth.Core.Entities.Base;

namespace White.Auth.Core.Interfaces.Base
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateAsync(TEntity entity);
    }
}
