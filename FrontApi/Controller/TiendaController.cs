using Business;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly CompraService _compraService;
        private readonly ArticuloService _articulosService;
        private readonly ClienteService _clienteService;
        private readonly TiendaService _tiendasService;
        private readonly InventarioService _inventarioService;

        public TiendaController(CompraService compraService, ArticuloService articuloService, ClienteService clienteService,TiendaService tiendaService, InventarioService inventarioService)
        {
            _compraService = compraService;
            _articulosService = articuloService;
            _clienteService = clienteService;
            _tiendasService = tiendaService;
            _inventarioService = inventarioService;
        }

        [HttpGet("Campras")]
        //[Authorize]
        public async Task<ActionResult<List<Compra>>> GetAll()
        {
            var compras = await _compraService.GetAllAsync();
            return Ok(compras);
        }
        [HttpGet("Clientes")]
        [Authorize]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteService.ObtenerClientes();
        }

        [HttpPost("Clientes")]
        public async Task<IActionResult> AddCliente(Cliente cliente)
        {
            await _clienteService.AgregarCliente(cliente);
            return Ok();
        }
        [HttpGet("Articulos")]
        public async Task<IEnumerable<Articulo>> GetArticulos()
        {
            return await _articulosService.ObtenerArticulos();
        }

        [HttpPost("Articulos")]
        public async Task<IActionResult> AddArticulo(Articulo articulo)
        {
            await _articulosService.AgregarArticulo(articulo);
            return Ok();
        }
        [HttpGet("Tiendas")]
        public async Task<IEnumerable<Tienda>> GetTiendas()
        {
            return await _tiendasService.ObtenerTiendas();
        }

        [HttpPost("Tiendas")]
        public async Task<IActionResult> AddTienda(Tienda tienda)
        {
            await _tiendasService.AgregarTienda(tienda);
            return Ok();
        }
    }
}
