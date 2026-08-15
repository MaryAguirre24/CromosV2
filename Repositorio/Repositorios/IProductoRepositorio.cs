using BD.Data.Entity;
using Shared.DTOs.Productos;

namespace Repositorio.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<bool> ActualizarProducto(ActualizarProductoDTO dto);
        Task<bool> DesactivarProducto(int id);
        Task<bool> ExisteCodigoProducto(string codigo);
        Task<int> InsertarProducto(Producto entidad);
        Task<List<ListaProductoDTO>> ObtenerListaProductos();
        Task<ListaProductoDTO> ObtenerProductoPorCodigo(string codigo);
        Task<ListaProductoDTO> ObtenerProductoPorId(int id);
        Task<List<ListaProductoDTO>> ObtenerProductosPorCategoria(int categoriaId);
        Task<List<ListaProductoDTO>> ObtenerProductosPorProveedor(int proveedorId);
    }
}