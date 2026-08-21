using BD.Data;
using BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs.Categorias;
using Shared.DTOs.Productos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
    public class ProductoRepositorio : Repositorio<Producto>, IRepositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext context;

        public ProductoRepositorio(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ListaProductoDTO>> ObtenerListaProductos()
        {
            var listaProductosDTO = await context.Productos
                .Include(p => p.Categoria)
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .ToListAsync();
            return listaProductosDTO;
        }

        public async Task<ListaProductoDTO> ObtenerProductoPorId(int id)
        {
            var producto = await context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Id == id)
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .FirstOrDefaultAsync();
            return producto;
        }

        public async Task<ListaProductoDTO> ObtenerProductoPorCodigo(string codigo)
        {
            var producto = await context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Codigo == codigo)
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .FirstOrDefaultAsync();
            return producto;
        }
        public async Task<int> InsertarProducto(Producto dto)
        {
            await context.Productos.AddAsync(dto);
            await context.SaveChangesAsync();
            return dto.Id;
        }

        public async Task<bool> ActualizarProducto(ActualizarProductoDTO dto)
        {
            var productoExistente = await context.Productos
                .FirstOrDefaultAsync(p => p.Id == dto.Id);
            if (productoExistente == null)
            {
                return false;
            }
            productoExistente.Codigo = dto.Codigo;
            productoExistente.Nombre = dto.Nombre;
            productoExistente.Descripcion = dto.Descripcion;
            productoExistente.PrecioVenta = dto.PrecioVenta;
            productoExistente.Stock = dto.Stock;
            productoExistente.Estado = dto.Estado;
            productoExistente.ProveedorId = dto.ProveedorId;
            productoExistente.CategoriaId = dto.CategoriaId;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DesactivarProducto(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto == null) return false;
            producto.Estado = false;
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<List<ListaProductoDTO>> ObtenerProductosPorCategoria(int categoriaId)
        {
            var listaProductosDTO = await context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.CategoriaId == categoriaId)
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .ToListAsync();
            return listaProductosDTO;
        }

        public async Task<List<ListaProductoDTO>> ObtenerProductosPorProveedor(int proveedorId)
        {
            var listaProductosDTO = await context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.ProveedorId == proveedorId)
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .ToListAsync();
            return listaProductosDTO;
        }
        public async Task<List<ListaProductoDTO>>BusquedaAvanzada(BusquedaAvanzadaDTO busqueda)
        {
            var query = context.Productos.Include(p => p.Categoria).AsQueryable();
            if (!string.IsNullOrEmpty(busqueda.Nombre))
            {
                query = query.Where(p => p.Nombre.Contains(busqueda.Nombre));
            }
            if (busqueda.CategoriaId.HasValue)
            {
                query = query.Where(p => p.CategoriaId == busqueda.CategoriaId.Value);
            }
            if (busqueda.StockMin.HasValue)
            {
                query = query.Where(p => p.Stock >= busqueda.StockMin.Value);
            }
            if (busqueda.StockMax.HasValue)
            {
                query = query.Where(p => p.Stock <= busqueda.StockMax.Value);
            }
            if (busqueda.PrecioMin.HasValue)
            {
                query = query.Where(p => p.PrecioVenta >= busqueda.PrecioMin.Value);
            }
            if (busqueda.PrecioMax.HasValue)
            {
                query = query.Where(p => p.PrecioVenta <= busqueda.PrecioMax.Value);
            }
            var listaProductosDTO = await query
                .Select(p => new ListaProductoDTO
                {
                    Codigo = p.Codigo,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    PrecioVenta = p.PrecioVenta,
                    Stock = p.Stock,
                    CategoriaNombre = p.Categoria.Nombre
                })
                .ToListAsync();
            return listaProductosDTO;
        }

        public async Task<bool> ExisteCodigoProducto(string codigo)
        {
            return await context.Productos.AnyAsync(p => p.Codigo == codigo);
        }
    }
}
