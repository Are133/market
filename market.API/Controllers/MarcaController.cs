namespace market.API.Controllers
{
    using market.Core.Entities;
    using market.Core.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IGenericRepository<Marca> _marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetAllMarca()
        {
            return Ok(await _marcaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>>GetMarcaById(int id)
        {
            return await _marcaRepository.GetByIdAsync(id);
        }
    }
}
