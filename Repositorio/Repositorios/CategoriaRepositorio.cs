using BD.Data;
using BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Categorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class CategoriaRepositorio : Repositorio<Categoria>, IRepositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext context;

        public CategoriaRepositorio(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ListaCategoriaDTO>> ObtenerCategorias()
        {
            var listaCategoriasDTO = await context.Categorias
                .Where(c => c.CategoriaPadreId == null)
                .Select(c => new ListaCategoriaDTO
                {
                    Id = c.Id,
                    CategoriaPadreId = c.Id,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado,
                    SubCategorias = c.SubCategorias.Select(sc => new ListaCategoriaDTO
                    {
                        Id = sc.Id,
                        CategoriaPadreId = sc.CategoriaPadreId,
                        Nombre = sc.Nombre,
                        Descripcion = sc.Descripcion,
                        Estado = sc.Estado
                    })
                    .ToList()
                })
                .ToListAsync();
            return listaCategoriasDTO;

        }
        public async Task<ListaCategoriaDTO> ObtenerCategoriaPorId(int id)
        {
            var categoria = await context.Categorias
                .Where (c => c.Id == id)
                .Select(c => new ListaCategoriaDTO
                {
                    CategoriaPadreId = c.CategoriaPadreId,
                    Nombre = c.Nombre,
                    Descripcion= c.Descripcion,
                    Estado = c.Estado,

                    SubCategorias = c.SubCategorias.Select(sc => new ListaCategoriaDTO
                    {
                        Id = sc.Id,
                        CategoriaPadreId= sc.CategoriaPadreId,
                        Nombre = sc.Nombre,
                        Descripcion = sc.Descripcion,
                        Estado= sc.Estado
                    })
                    .ToList()

                })
                .FirstOrDefaultAsync();
            return categoria;
        }
        public async Task<int> InsertarCategoria(Categoria dto)
        {
            await context.Categorias.AddAsync(dto);
            await context.SaveChangesAsync();
            return dto.Id;
        }
        public async Task<bool> ActualizarCategoria(ActualizarCategoriaDTO dto)
        {
            if(dto.CategoriaPadreId.HasValue && dto.CategoriaPadreId.Value == dto.Id)
            {
                return false;
            }
            var categoria = await context.Categorias
                .FindAsync(dto.Id);
            if (categoria == null)
            {
                return false;
            }
            categoria.CategoriaPadreId = dto.CategoriaPadreId;
            categoria.Nombre = dto.Nombre;
            categoria.Descripcion = dto.Descripcion;
            categoria.Estado = dto.Estado;
            await context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DesactivarCategoria(int id)
        {
            var categoria = await context.Categorias.FindAsync(id);
            if(categoria == null)
            {
                return false;
            }
            categoria.Estado = false;
            await context.SaveChangesAsync();
            return true;

        }
    }


}
