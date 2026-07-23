using BD.Data;
using BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Repositorio.Repositorios;

namespace Cromos.Controllers
{
    [ApiController]
    [Route("api/Persona")]
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRepositorio<Persona> repositorio;

        public PersonaController(ApplicationDbContext context , IRepositorio<Persona> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VerPersonaDTO>> ObtenerPersonaPorId(int id)
        {
            var persona = await context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound("Persona no encontrada");
            }
            return Ok(persona);
        }

        [HttpPost]
        public async Task<ActionResult> CrearPersona([FromBody] CrearPersonaDTO dto)
        {
            try
            {
                bool existeemail = await context.Personas.AnyAsync(p => p.Email == dto.Email);
                if (existeemail)
                {
                    return BadRequest("El email ya está registrado");
                }
                var persona = new Persona
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Telefono = dto.Telefono,
                    Email = dto.Email
                };
                var idPersona = await repositorio.Insert(persona);
                return Ok(idPersona);


            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la persona: {ex.Message}");
            }
        }

    }
}
