using System.ComponentModel.DataAnnotations;

namespace TechOil.Modelos
{
    public class Servicio
    {
        [Key]
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public decimal ValorHora { get; set; }
    }
}
