using BD.Data;
using BD.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using Shared.DTOs.Productos;

namespace Cromos.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IProductoRepositorio productoRepositorio;

        public ProductoController(ApplicationDbContext context, IProductoRepositorio productoRepositorio)
        {
            this.context = context;
            this.productoRepositorio = productoRepositorio;
        }

        [HttpGet("lista")]
        public async Task<ActionResult<List<ListaProductoDTO>>> ListaProductos()
        {
            var lista = await productoRepositorio.ObtenerListaProductos();
            if (lista == null)
            {
                return BadRequest("Error al obtener los productos");
            }
            if (lista.Count == 0)
            {
                return NotFound("No se encontraron productos");
            }
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaProductoDTO>> ObtenerProductoPorId(int id)
        {
            var producto = await productoRepositorio.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }
            return Ok(producto);
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<ActionResult<ListaProductoDTO>> ObtenerProductoPorCodigo(string codigo)
        {
            var producto = await productoRepositorio.ObtenerProductoPorCodigo(codigo);
            if (producto == null)
            {
                return NotFound("Producto no encontrado");
            }
            return Ok(producto);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> CrearProducto([FromBody] CrearProductoDTO dto)
        {
            try
            {
                bool existeCodigo = await productoRepositorio.ExisteCodigoProducto(dto.Codigo);
                if (existeCodigo) {
                    return BadRequest("El código del producto ya existe");
                }

                var producto = new Producto
                {
                    Codigo = dto.Codigo,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    PrecioVenta = dto.PrecioVenta,
                    Stock = dto.Stock,
                    CategoriaId = dto.CategoriaId,
                    ProveedorId = dto.ProveedorId
                };
                var IdProducto = await productoRepositorio.InsertarProducto(producto);
                return Ok(IdProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al crear el producto",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult> EditarProducto(int id, [FromBody] ActualizarProductoDTO dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("El ID del producto no coincide");
                }
                var productoExistente = await productoRepositorio.ObtenerProductoPorId(id);
                if (productoExistente == null)
                {
                    return NotFound("Producto no encontrado");
                }
                bool existeCodigo = await productoRepositorio.ExisteCodigoProducto(dto.Codigo);
                if (existeCodigo && productoExistente.Codigo != dto.Codigo)
                {
                    return BadRequest("El código del producto ya existe");
                }
                bool actualizado = await productoRepositorio.ActualizarProducto(dto);
                if (!actualizado)
                {
                    return BadRequest("Error al actualizar el producto");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al crear el producto",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DesactivarProducto(int id)
        {
            try
            {
                bool desactivado = await productoRepositorio.DesactivarProducto(id);
                if (!desactivado)
                {
                    return NotFound(new { mensaje = $"No se encontró el producto con ID {id}" });
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al desactivar el producto",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult> ObtenerProductosPorCategoria(int categoriaId)
        {
            var productos = await productoRepositorio.ObtenerProductosPorCategoria(categoriaId);
            return Ok(productos);
        }

    }
}