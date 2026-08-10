using Microsoft.EntityFrameworkCore;
using BD.Data;
using BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly ApplicationDbContext context;

        public PersonaRepositorio(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> InsertarPersona(Persona entidad)
        {
            await context.Personas.AddAsync(entidad);
            await context.SaveChangesAsync();
            return entidad.Id;
        }

        public async Task<Persona> ObtenerPersonaPorId(int id)
        {
            var persona = await context.Personas.FindAsync(id);
            return persona;
        }
        public async Task<bool> ExisteEmail(string email)
        {
            return await context.Personas.AnyAsync(p => p.Email == email);
        }
    }
}
