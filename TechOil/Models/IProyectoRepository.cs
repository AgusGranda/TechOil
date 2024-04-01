namespace TechOil.Modelos
{
    public interface IProyectoRepository
    {
        Task<IEnumerable<Proyecto>> GetAllProyectos();
        Task<Proyecto> GetProyectoById(int id);
        Task AddProyecto(Proyecto proyecto);
        Task UpdateProyecto(Proyecto proyecto);
        Task DeleteProyecto(int id);
    }
}
