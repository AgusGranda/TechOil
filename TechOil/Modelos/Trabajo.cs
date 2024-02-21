using Microsoft.VisualBasic;

namespace TechOil.Modelos
{
    public class Trabajo
    {
        public int CodTrabajo { get; set; }
        public DateAndTime Fecha { get; set; }
        public Proyecto CodProyecto { get; set; }
        public Servicio CodServicio { get; set; }
        public int CantHora { get; set; }
        public int ValorHora { get; set; }
        public decimal Costo { get; set; }      
    }
}
