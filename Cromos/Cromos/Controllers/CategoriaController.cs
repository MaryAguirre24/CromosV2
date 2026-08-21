using BD.Data;
using BD.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using Shared.DTOs.Categorias;

namespace Cromos.Controllers
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoriaRepositorio categoriaRepositorio;

        public CategoriaController(ApplicationDbContext context, ICategoriaRepositorio categoriaRepositorio)
        {
            this.context = context;
            this.categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet("listacategorias")]
        public async Task<ActionResult<List<ListaCategoriaDTO>>> ListaCategorias()
        {
            var lista = await categoriaRepositorio.ObtenerCategorias();
            if(lista == null)
            {
                return BadRequest("Error al obtener las categorias");
            }
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaCategoriaDTO>> ObtenerCategoriaPorId(int id)
        {
            var categoria = await categoriaRepositorio.ObtenerCategoriaPorId(id);
            if(categoria == null)
            {
                return NotFound("Categoria no encontrada");
            }
            return Ok(categoria);
        }
        [HttpPost("crear")]
        public async Task<ActionResult> CrearCategoria([FromBody] CrearCategoriaDTO dto)
        {
            try
            {
                var nuevaCategoria = new Categoria
                {
                    CategoriaPadreId = dto.CategoriaPadreId,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    Estado = dto.Estado
                };
                var categoriaCreada = await categoriaRepositorio.InsertarCategoria(nuevaCategoria);
                return Ok(new
                {
                    mensaje = "Categoria creada correctamente",
                    categoria = categoriaCreada
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensaje = "Error al crear la categoria",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
 
        }
        [HttpPut("actualizar/{id}")]
        public async Task<ActionResult> ActualizarCategoria(int id, [FromBody] ActualizarCategoriaDTO dto)
        {
            try
            {
                var categoriaExistente = await categoriaRepositorio.ObtenerCategoriaPorId(id);
                if (categoriaExistente == null)
                {
                    return NotFound("Categoria no encontrada");
                }
                categoriaExistente.CategoriaPadreId = dto.CategoriaPadreId;
                categoriaExistente.Nombre = dto.Nombre;
                categoriaExistente.Descripcion = dto.Descripcion;
                categoriaExistente.Estado = dto.Estado;
                await categoriaRepositorio.ActualizarCategoria(dto);
                return Ok(new
                {
                    mensaje = "Categoria actualizada correctamente",
                    categoria = categoriaExistente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al actualizar la categoria",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpDelete("desactivar/{id}")]
        public async Task<ActionResult> DesactivarCategoria(int id)
        {
            try
            {
                var categoriaExistente = await categoriaRepositorio.ObtenerCategoriaPorId(id);
                if (categoriaExistente == null)
                {
                    return NotFound("Categoria no encontrada");
                }
                await categoriaRepositorio.DesactivarCategoria(id);
                return Ok(new
                {
                    mensaje = "Categoria desactivada correctamente",
                    categoria = categoriaExistente
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al desactivar la categoria",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
