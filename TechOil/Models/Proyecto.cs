using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TechOil.Modelos
{
    public class Proyecto
    {
        [Key]
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
    }
}
