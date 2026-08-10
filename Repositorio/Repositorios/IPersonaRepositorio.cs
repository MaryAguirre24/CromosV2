using BD.Data.Entity;

namespace Repositorio.Repositorios
{
    public interface IPersonaRepositorio : IRepositorio<Persona>
    {
        Task<bool> ExisteEmail(string email);
        Task<int> InsertarPersona(Persona dto);
        Task<Persona> ObtenerPersonaPorId(int id);
    }
}