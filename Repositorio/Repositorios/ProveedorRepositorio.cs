using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BD.Data;
using BD.Data.Entity;
using Shared.DTOs.Proveedores;

namespace Repositorio.Repositorios
{
    public class ProveedorRepositorio : Repositorio<Proveedor>, IRepositorio<Proveedor>, IProveedorRepositorio
    {
        private readonly ApplicationDbContext context;

        public ProveedorRepositorio(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<List<ProveedorDTO>> ObtenerListaProveedores()
        {
            var lista = await context.Proveedores
                .Select(p => new ProveedorDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Email = p.Email,
                    Telefono = p.Telefono
                })
                .ToListAsync();
            return lista;
        }
        public async Task<ProveedorDTO> ObtenerProveedorPorId(int id)
        {
            var proveedor = await context.Proveedores
                .Where(p => p.Id == id)
                .Select(p => new ProveedorDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Email = p.Email,
                    Telefono = p.Telefono
                })
                .FirstOrDefaultAsync();
            return proveedor;
        }
        public async Task<int> InsertarProveedor(CrearProveedorDTO dto)
        {
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Telefono = dto.Telefono
            };
            context.Proveedores.Add(proveedor);
            await context.SaveChangesAsync();
            return proveedor.Id;
        }
        public async Task<bool> ActualizarProveedor(ActualizarProveedorDTO dto)
        {
            var proveedor = await context.Proveedores.FindAsync(dto.Id);
            if (proveedor == null)
            {
                return false;
            }
            proveedor.Nombre = dto.Nombre;
            proveedor.Email = dto.Email;
            proveedor.Telefono = dto.Telefono;
            await context.SaveChangesAsync();
            return true;
        }
    }

}
