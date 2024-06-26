﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TechOil.Modelos
{
    public class Usuario
    {
        [Key]
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contraseña { get; set; }
    }
}
