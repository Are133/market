using market.Core.Entities;
using market.Core.Entities.Especifications;
using market.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _productoRepository;

        public ProductoController(IGenericRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await _productoRepository.GetAllWithSpec(spec);
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>>GetProduct(int id)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            return await _productoRepository.GetByIdWithSpec(spec);
        }
    }
}
