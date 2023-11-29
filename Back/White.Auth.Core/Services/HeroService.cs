using VaiDeEscolar.Domain.Interfaces.Repositories;

using White.Auth.Core.Entities;
using White.Auth.Core.Interfaces.Services;

namespace White.Auth.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public HeroService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Hero entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Hero.CreateAsync(entity);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.Hero.GetByIdAsync(id);

                if (entity != null)
                {
                    await _unitOfWork.Hero.DeleteByAsync(entity).ConfigureAwait(false);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync()
        {
            return await _unitOfWork.Hero.GetAllAsync();
        }

        public async Task<Hero> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.Hero.GetByIdAsync(id);

                if (entity != null)
                    return entity;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(Hero entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Hero.UpdateAsync(entity);
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
