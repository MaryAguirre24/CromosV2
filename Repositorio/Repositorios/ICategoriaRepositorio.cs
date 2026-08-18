using BD.Data.Entity;
using Shared.DTOs.Categorias;

namespace Repositorio.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task<bool> ActualizarCategoria(ActualizarCategoriaDTO dto);
        Task<bool> DesactivarCategoria(int id);
        Task<int> InsertarCategoria(Categoria dto);
        Task<ListaCategoriaDTO> ObtenerCategoriaPorId(int id);
        Task<List<ListaCategoriaDTO>> ObtenerCategorias();
    }
}