using White.Auth.Core.Entities;
using White.Auth.Core.Interfaces.Repositories;
using White.Auth.Infra.Data.Context;
using White.Auth.Infra.Data.Repository.Base;

namespace White.Auth.Infra.Data.Repository
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appContext) : base(appContext)
        {

        }
    }
}
