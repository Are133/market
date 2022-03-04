namespace market.BusinessLogic.Logic
{
    using market.BusinessLogic.Data;
    using market.Core.Entities;
    using market.Core.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : IProductoRepository
    {
        private readonly MarketDbContext _context;
        public ProductRepository(MarketDbContext context)
        {
            _context = context;
        }
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.Include(producto => producto.Marca)
                .Include(producto => producto.Categoria)
                .FirstOrDefaultAsync(producto => producto.Id == id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Productos.Include(producto => producto.Marca)
                .Include(producto => producto.Categoria)
                .ToListAsync();
        }
    }
}
