namespace TechOil.Modelos
{
    public interface ITrabajoRepository
    {
        Task<IEnumerable<Trabajo>> GetAllTrabajos();
        Task<IEnumerable<Trabajo>> GetTrabajoByEstado(int estado);
        Task<Trabajo> GetTrabajoById(int id);
        Task AddTrabajo(Trabajo trabajo);
        Task UpdateTrabajo(Trabajo trabajo);
        Task DeleteTrabajo(int id);
    }
}
