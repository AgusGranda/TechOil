using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Modelos;

namespace TechOil.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyDbContext _proyectoDb;

        public UsuarioRepository(MyDbContext proyectoDb)
        {
            _proyectoDb = proyectoDb;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _proyectoDb.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _proyectoDb.Usuarios.FirstOrDefaultAsync(x => x.CodUsuario == id);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _proyectoDb.Usuarios.AddAsync(usuario);
            await _proyectoDb.SaveChangesAsync();
        }
        public async Task AddUsuario(Usuario usuario)
        {
            _proyectoDb.Usuarios.Update(usuario);
            await _proyectoDb.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            var usuarioToDelete = _proyectoDb.Usuarios.FirstOrDefaultAsync(x => x.CodUsuario == id);
            _proyectoDb.Remove(usuarioToDelete);
            await _proyectoDb.SaveChangesAsync();
        }

    }
}
