namespace TechOil.Modelos
{
    public interface IServicioRepository
    {
        IEnumerable<Servicio> GetAllServicios();
        Servicio GetServicioById(int id);
        void AddServicio(Servicio servicio);
        void UpdateServicio(Servicio servicio);
        void DeleteServicioById(int id);
    }
}
