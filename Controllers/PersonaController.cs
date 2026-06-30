using BD.Data;
using BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Cromos.Controllers
{
    [ApiController]
    [Route("api/Persona")]
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VerPersonaDTO>>> ObtenerPersona()
        {
            var personas = await context.Personas.ToListAsync();
            if (personas == null)
            {
                return BadRequest("Error al obtener las personas");
            }
            if (personas.Count == 0)
            {
                return NotFound("No se encontraron personas");
            }
            return Ok(personas);
        }
    }
}
