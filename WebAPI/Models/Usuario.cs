using System;

namespace WebAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string DniUsuario { get; set; }
        public string PassUsuario { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
    }
}