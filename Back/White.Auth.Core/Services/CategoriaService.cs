using VaiDeEscolar.Domain.Interfaces.Repositories;

using White.Auth.Core.Entities;
using White.Auth.Core.Interfaces.Services;

namespace White.Auth.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public CategoriaService(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(Categoria entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Categoria.CreateAsync(entity);
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
                var entity = await _unitOfWork.Categoria.GetByIdAsync(id);

                if (entity != null)
                {
                    await _unitOfWork.Categoria.DeleteByAsync(entity).ConfigureAwait(false);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _unitOfWork.Categoria.GetAllAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.Categoria.GetByIdAsync(id);

                if (entity != null)
                    return entity;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(Categoria entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Categoria.UpdateAsync(entity);
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
