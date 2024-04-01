using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace TechOil.Modelos
{
    public class Trabajo
    {
        [Key]
        public int CodTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHora { get; set; }
        public int ValorHora { get; set; }
        public decimal Costo { get; set; }      
    }
}
