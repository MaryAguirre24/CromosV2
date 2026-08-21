using BD.Data.Entity;
using Shared.DTOs.Proveedores;

namespace Repositorio.Repositorios
{
    public interface IProveedorRepositorio
    {
        Task<bool> ActualizarProveedor(ActualizarProveedorDTO dto);
        Task<int> InsertarProveedor(CrearProveedorDTO dto);
        Task<List<ProveedorDTO>> ObtenerListaProveedores();
        Task<ProveedorDTO> ObtenerProveedorPorId(int id);
    }
}