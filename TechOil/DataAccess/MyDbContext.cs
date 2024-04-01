using Microsoft.EntityFrameworkCore;
using TechOil.Modelos;

namespace TechOil.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-76KGP02\\SQLEXPRESS;Initial Catalog=TechOil_DB;Persist Security Info = True;Trusted_Connection = SSPI;MultipleActiveResultSets=True; Trust Server Certificate= True");
        }


    }
}
