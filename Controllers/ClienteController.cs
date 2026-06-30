using BD.Data;
using BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorios;
using Shared.DTOs;

namespace Cromos.Controllers
{
    [ApiController]
    [Route("api/Cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteController(ApplicationDbContext context , IRepositorio<Cliente> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaClienteDTO>>> ObtenerCliente()
        {
            var clientes = await repositorio.SelectLista();
            if (clientes == null)
            {
                return BadRequest("Error al obtener los clientes");
            }
            if (clientes.Count == 0)
            {
                return NotFound("No se encontraron clientes");
            }
            return Ok(clientes);
        }
        [HttpGet("listaClientes")]
        public async Task<ActionResult<List<ListaClienteDTO>>> ListaClientes()
        {
            var listaclientes = await repositorio.SelectLista();
            if (listaclientes == null)
            {
                return BadRequest("Error al obtener los clientes");
            }
            if (listaclientes.Count == 0)
            {
                return NotFound("No se encontraron clientes");
            }
            return Ok(listaclientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListaClienteDTO>> ObtenerClientePorId(int id)
        {
            var cliente = await repositorio.SelectById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            return Ok(cliente);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> CrearCliente([FromBody] CrearClienteDTO dto)
        {
            try
            {
                bool existePersona = await context.Personas.AnyAsync(p => p.Email == dto.Email);
                if (existePersona)
                {
                    return BadRequest("Ya existe una persona con el mismo correo electrónico");
                }
                var persona = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Telefono = dto.Telefono
                };
                var cliente = new Cliente
                {
                    Persona = persona,
                    Estado = dto.Estado
                };
                var idCliente = await repositorio.Insert(cliente);
                return Ok(new { mensaje = "Cliente creado exitosamente", idCliente });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensaje = "Error al crear el cliente",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }

        }
        [HttpPut("editar/{id}")]
        public async Task<ActionResult> EditarCliente(int id, [FromBody] EditarClienteDTO dto)
        {
            try
            {
                var cliente = await context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                var persona = cliente.Persona;
                persona.Nombre = dto.Nombre;
                persona.Apellido = dto.Apellido;
                persona.Email = dto.Email;
                persona.Telefono = dto.Telefono;

                await context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al editar el cliente",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            try
            {
                var cliente = await context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al eliminar el cliente",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }

    }
}
