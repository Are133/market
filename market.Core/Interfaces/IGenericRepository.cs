
namespace market.Core.Interfaces
{
    using market.Core.Entities;
    using market.Core.Entities.Especifications;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<T> where T : ClaseBase
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWithSpec(IEspecification<T> spec);

        Task<IReadOnlyList<T>> GetAllWithSpec(IEspecification<T> spec);

        Task<int> CountAsync(IEspecification<T> spec);
    }
}
