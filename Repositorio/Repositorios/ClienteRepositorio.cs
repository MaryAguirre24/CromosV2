using Microsoft.EntityFrameworkCore;
using BD.Data; 
using BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.DTOs;

namespace Repositorio.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IRepositorio<Cliente>, IClienteRepositorio
    {
        private readonly ApplicationDbContext context;

        public ClienteRepositorio(ApplicationDbContext context): base(context) 
        {
            this.context = context;
        }

        public async Task<List<ListaClienteDTO>> ObtenerListaClientesDTO()
        {
            var listaclientesDTO = await context.Clientes
                .Include(c => c.Persona)
                .Include(c => c.MovimientosCuentaCorriente)
                .Select(c => new ListaClienteDTO
                {
                    Id = c.Id,
                    NombreCompleto = $"{c.Persona.Nombre} {c.Persona.Apellido}".Trim(),
                    Email = c.Persona.Email,
                    Telefono = c.Persona.Telefono,
                    FechaRegistro = c.FechaRegistro,
                    Deuda = c.MovimientosCuentaCorriente.Sum(m => m.Monto),
                    Estado = c.Estado
                })
                .ToListAsync();

            return listaclientesDTO;
        }

        public async Task<ListaClienteDTO> ObtenerClientePorId(int id)
        {
            var cliente = await context.Clientes
                .Include(c => c.Persona)
                .Include(c => c.MovimientosCuentaCorriente)
                .Where(c => c.Id == id)
                .Select(c => new ListaClienteDTO
                {
                    Id = c.Id,
                    NombreCompleto = c.Persona.Nombre + " " + c.Persona.Apellido,
                    Email = c.Persona.Email,
                    Telefono = c.Persona.Telefono,
                    FechaRegistro = c.FechaRegistro,
                    Deuda = c.MovimientosCuentaCorriente.Sum(m => m.Monto),
                    Estado = c.Estado
                })
                .FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<int> InsertarCliente(Cliente dto)
        {
            await context.Clientes.AddAsync(dto);
            await context.SaveChangesAsync();
            return dto.Id;
        }
        public async Task<bool> ActualizarCliente(Cliente dto)
        {
            var clienteExistente = await context.Clientes
                .Include(c => c.Persona)
                .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (clienteExistente == null)
            {
                return false;
            }

            clienteExistente.Persona.Nombre = dto.Persona.Nombre;
            clienteExistente.Persona.Apellido = dto.Persona.Apellido;
            clienteExistente.Persona.Email = dto.Persona.Email;
            clienteExistente.Persona.Telefono = dto.Persona.Telefono;
            clienteExistente.Estado = dto.Estado;

            await context.SaveChangesAsync();

            return true;
        }
        public async Task<List<ListaClienteDTO>> ObtenerClientesDeudores()
        {
            return await context.Clientes
                .Include(c => c.Persona)
                .Include(c => c.MovimientosCuentaCorriente)
                .Where(c => c.MovimientosCuentaCorriente.Sum(m => m.Monto) > 0)
                .Select(c => new ListaClienteDTO
                {
                    Id = c.Id,
                    NombreCompleto = c.Persona.Nombre + " " + c.Persona.Apellido,
                    Email = c.Persona.Email,
                    Telefono = c.Persona.Telefono,
                    FechaRegistro = c.FechaRegistro,
                    Deuda = c.MovimientosCuentaCorriente.Sum(m => m.Monto),
                    Estado = c.Estado
                })
                .ToListAsync();
        }
        public async Task<EditarClienteDTO?> ObtenerClienteEditar(int id)
        {
            return await context.Clientes
                .Include(c => c.Persona)
                .Where(c => c.Id == id)
                .Select(c => new EditarClienteDTO
                {
                    Nombre = c.Persona.Nombre,
                    Apellido = c.Persona.Apellido,
                    Email = c.Persona.Email,
                    Telefono = c.Persona.Telefono,
                    Estado = c.Estado
                })
                .FirstOrDefaultAsync();
        }
    }
}
