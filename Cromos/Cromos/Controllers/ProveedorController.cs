using BD.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Repositorios;
using Shared.DTOs.Proveedores;

namespace Cromos.Controllers
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IProveedorRepositorio proveedorRepositorio;

        public ProveedorController(ApplicationDbContext context, IProveedorRepositorio proveedorRepositorio)
        {
            this.context = context;
            this.proveedorRepositorio = proveedorRepositorio;
        }
        [HttpGet("lista-proveedores")]
        public async Task<ActionResult<List<ProveedorDTO>>> ObtenerListaProveedores()
        {
            var lista = await proveedorRepositorio.ObtenerListaProveedores();
            if (lista == null)
            {
                return BadRequest("Error al obtener los proveedores");
            }
            return Ok(lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> ObtenerProveedorPorId(int id)
        {
            var proveedor = await proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedor == null)
            {
                return NotFound("Proveedor no encontrado");
            }
            return Ok(proveedor);
        }
        [HttpPost("Crear")]
        public async Task<ActionResult<int>> CrearProveedor([FromBody] CrearProveedorDTO dto)
        {
            var proveedor = new ProveedorDTO
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Direccion = dto.Direccion,
                Coeficiente = dto.Coeficiente,
                Estado = dto.Estado
            };
            var idProveedor = await proveedorRepositorio.InsertarProveedor(dto);
            if (idProveedor <= 0)
            {
                return BadRequest("Error al crear el proveedor");
            }
            return Ok(idProveedor);
        }
        [HttpPut("Actualizar")]
        public async Task<ActionResult<bool>> ActualizarProveedor([FromBody] ActualizarProveedorDTO dto)
        {
            var resultado = await proveedorRepositorio.ActualizarProveedor(dto);
            if (!resultado)
            {
                return BadRequest("Error al actualizar el proveedor");
            }
            return Ok(resultado);
        }
    }


}
