using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Modelos;

namespace TechOil.Repository
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly MyDbContext _proyectoDb;

        public ServicioRepository(MyDbContext proyectoDb)
        {
            _proyectoDb = proyectoDb;
        }


        public async Task<IEnumerable<Servicio>> GetAllServicios()
        {
            return await _proyectoDb.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            return await _proyectoDb.Servicios.FirstOrDefaultAsync(x => x.CodServicio == id);
        }
        public async Task AddServicio(Servicio servicio)
        {
            await _proyectoDb.Servicios.AddAsync(servicio);
            await _proyectoDb.SaveChangesAsync();
        }
        public async Task UpdateServicio(Servicio servicio)
        {
            _proyectoDb.Servicios.Update(servicio);
            await _proyectoDb.SaveChangesAsync();
        }
       

        public async Task DeleteServicioById(int id)
        {
            var servicioToDelete = _proyectoDb.Servicios.FirstOrDefaultAsync(x => x.CodServicio == id);
            _proyectoDb.Remove(servicioToDelete);
            await _proyectoDb.SaveChangesAsync();
        }
    }
}
