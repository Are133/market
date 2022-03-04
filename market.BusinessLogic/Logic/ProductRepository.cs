namespace market.BusinessLogic.Logic
{
    using market.Core.Entities;
    using market.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : IProductoRepository
    {
        public Task<Producto> GetProductoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
