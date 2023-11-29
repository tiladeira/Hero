using VaiDeEscolar.Domain.Interfaces.Repositories;

using White.Auth.Core.Interfaces.Repositories;
using White.Auth.Infra.Data.Context;

namespace White.Auth.Infra.Data.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly AppDbContext _dbContext;

        public IHeroRepository Hero { get; }
        public ICategoriaRepository Categoria { get; }

        public UnitOfWorkRepository(AppDbContext dbContext,
                          IHeroRepository hero,
                          ICategoriaRepository categoria)
        {
            _dbContext = dbContext;
            Hero = hero;
            Categoria = categoria;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();
        }
    }
}
