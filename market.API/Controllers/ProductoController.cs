using AutoMapper;
using market.API.DTos;
using market.API.Errors;
using market.Core.Entities;
using market.Core.Entities.Especifications;
using market.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : BaseAPIController
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDto >>> GetProductos([FromQuery] ProductoSpecificationParams productoSpecificationParams)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(productoSpecificationParams);
            var productos = await _productoRepository.GetAllWithSpec(spec);

            var specCount = new ProductoForCountingSpecification(productoSpecificationParams);

            var totalProductos = await _productoRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoSpecificationParams.PageSize));

            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);

            return Ok(new Pagination<ProductoDto>
            {
                Count = totalProductos,
                Data = data,
                PageCount = totalPages,
                PageIndex = productoSpecificationParams.PageIndex,
                PageSize = productoSpecificationParams.PageSize
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            var producto = await _productoRepository.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }

            return _mapper.Map<Producto, ProductoDto>(producto);
        }
    }
}
