using TechOil.Modelos;

namespace TechOil.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Task <Usuario> LoginUsuario(string nombre, string contraseña);
    }
}
