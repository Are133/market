namespace market.Core.Interfaces
{
    using market.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductoRepository
    {
        Task<Producto> GetProductoByIdAsync(int id);

        Task<IReadOnlyList<Producto>> GetProductosAsync();
    }
}
