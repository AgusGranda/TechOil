using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Modelos;

namespace TechOil.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {

        private readonly MyDbContext _proyectoDb;

        public ProyectoRepository(MyDbContext proyectoDb)
        {
            _proyectoDb = proyectoDb;
        }
       

        public async Task<IEnumerable<Proyecto>> GetAllProyectos()
        {
            return await _proyectoDb.Proyectos.ToListAsync();

        }

        public async Task<Proyecto> GetProyectoById(int id)
        {
            return await _proyectoDb.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == id);
        }
        public async Task AddProyecto(Proyecto proyecto)
        {

            await _proyectoDb.Proyectos.AddAsync(proyecto);
            await _proyectoDb.SaveChangesAsync();
        }

        public async Task UpdateProyecto(Proyecto proyecto)
        {
            _proyectoDb.Proyectos.Update(proyecto);
            await _proyectoDb.SaveChangesAsync();

        }
       

        public async Task DeleteProyecto(int id)
        {
            var proyectoToDelete =_proyectoDb.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == id);
            _proyectoDb.Remove(proyectoToDelete);
            await _proyectoDb.SaveChangesAsync();
        }
    }
}
