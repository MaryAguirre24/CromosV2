using BD.Data.Entity;
using Shared.DTOs;

namespace Repositorio.Repositorios
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
       Task<List<ListaClienteDTO>> ObtenerListaClientesDTO();
       Task<List<ListaClienteDTO>> ObtenerClientesDeudores();
       Task<int> InsertarCliente(Cliente entidad);
        Task<bool> ActualizarCliente(Cliente dto);
        Task<ListaClienteDTO> ObtenerClientePorId(int id);
        Task<EditarClienteDTO?> ObtenerClienteEditar(int id);
    }
}