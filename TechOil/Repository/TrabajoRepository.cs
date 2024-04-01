using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Modelos;

namespace TechOil.Repository
{
    public class TrabajoRepository : ITrabajoRepository
    {

        private readonly MyDbContext _proyectoDb;

        public TrabajoRepository(MyDbContext proyectoDb)
        {
            _proyectoDb = proyectoDb;
        }


        public async Task<IEnumerable<Trabajo>> GetAllTrabajos()
        {
            return await _proyectoDb.Trabajos.ToListAsync();
        }
        public async Task<IEnumerable<Trabajo>> GetTrabajoByEstado(int estado)
        {
            throw new NotImplementedException();
            // hacer linq para filtrar
           // return await _proyectoDb.Trabajos.
        }
        public async Task<Trabajo> GetTrabajoById(int id)
        {
            return await _proyectoDb.Trabajos.FirstOrDefaultAsync(x => x.CodTrabajo == id);
        }
        public async Task AddTrabajo(Trabajo trabajo)
        {
            await _proyectoDb.Trabajos.AddAsync(trabajo);
            await _proyectoDb.SaveChangesAsync();
        }

        public async Task UpdateTrabajo(Trabajo trabajo)
        {
            _proyectoDb.Trabajos.Update(trabajo);
            await _proyectoDb.SaveChangesAsync();
        }
       

        public async Task DeleteTrabajo(int id)
        {
            var trabajoToDelete = _proyectoDb.Trabajos.FirstOrDefaultAsync(x => x.CodTrabajo == id);
            _proyectoDb.Remove(trabajoToDelete);
            await _proyectoDb.SaveChangesAsync();
        }
    }
}
