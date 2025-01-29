using System;

namespace WebAPI.Models
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public int IdRegion { get; set; }
        public int IdUserCreate { get; set; }
        public string NombreProvincia { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }

        // Relacion con las tabla Region
        public Region Region { get; set; }
    }
}