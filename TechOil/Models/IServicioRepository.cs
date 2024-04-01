namespace TechOil.Modelos
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllServicios();
        Task<Servicio> GetServicioById(int id);
        Task AddServicio(Servicio servicio);
        Task UpdateServicio(Servicio servicio);
        Task DeleteServicioById(int id);
    }
}
