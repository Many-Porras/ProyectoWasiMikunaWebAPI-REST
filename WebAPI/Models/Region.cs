using System;

namespace WebAPI.Models
{
    public class Region
    {
        public int IdRegion { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
    }
}