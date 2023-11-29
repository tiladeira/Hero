using White.Auth.Core.Interfaces.Repositories;

namespace VaiDeEscolar.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {        
        ICategoriaRepository Categoria { get; }
        IHeroRepository Hero { get; }

        int Save();
    }
}
