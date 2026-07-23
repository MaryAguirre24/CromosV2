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
        private readonly IClienteRepositorio repositorio;

        public ClienteController(ApplicationDbContext context , IClienteRepositorio repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet("listaClientes")]
        public async Task<ActionResult<List<ListaClienteDTO>>> ListaClientes()
        {
            var lista = await repositorio.ObtenerListaClientesDTO();
            if (lista == null)
            {
                return BadRequest("Error al obtener los clientes");
            }
            if (lista.Count == 0)
            {
                return NotFound("No se encontraron clientes");
                Console.WriteLine($"Cantidad de clientes: {lista.Count}");
            }
            return Ok(lista);
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
                var persona = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Telefono = dto.Telefono
                };
                await context.Personas.AddAsync(persona);
                await context.SaveChangesAsync();

                var cliente = new Cliente
                {
                    PersonaId = persona.Id,
                    Estado = dto.Estado,
                    FechaRegistro = DateTime.Now
                };
                var idCliente = await repositorio.Insert(cliente);
                return Ok(idCliente );
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
                var cliente = await context.Clientes
                    .Include(c => c.Persona)
                    .FirstOrDefaultAsync(c => c.Id == id);
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
