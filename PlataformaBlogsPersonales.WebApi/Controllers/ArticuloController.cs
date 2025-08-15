using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaBlogsPersonales.Infraestructura.Servicios.Interfaces;
using PlataformaBlogsPersonales.Model.DTOs.ArticuloDTOs;
using PlataformaBlogsPersonales.Model.Models;

namespace PlataformaBlogsPersonales.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        
        private readonly IArticuloServicios _articuloServicios;
        
        public ArticuloController(IArticuloServicios articuloServicios)
        {
            _articuloServicios = articuloServicios ?? throw new ArgumentNullException(nameof(articuloServicios));
        }

        [HttpGet("ListaArticulos")]
        public async Task<IActionResult> ListaArticulos([FromQuery] FiltroArticuloDTO filtro)
        {
            try
            {
                var articulos = await _articuloServicios.ListaArticulos(filtro);
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener la lista de artículos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerArticuloPorId(Guid id)
        {
            try
            {
                var articulo = await _articuloServicios.ObtenerArticuloPorId(id);
                return Ok(articulo);
            }
            catch (Exception ex)
            {
                return NotFound($"Artículo con ID {id} no encontrado: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearArticulo([FromBody] ArticuloDTO articulo)
        {
            try
            {
                var result = await _articuloServicios.CrearArticulo(articulo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el artículo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarArticulo(Guid id)
        {
            try
            {
                await _articuloServicios.EliminarArticulo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"Artículo con ID {id} no encontrado: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArticulo(Guid id, [FromBody] Articulo articuloActualizado)
        {
            try
            {
                await _articuloServicios.ActualizarArticulo(id, articuloActualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el artículo: {ex.Message}");
            }
        }
    }
}
