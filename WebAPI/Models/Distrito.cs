using Microsoft.SqlServer.Types;
using System;

namespace WebAPI.Models
{
    public class Distrito
    {
        public int IdDistrito { get; set; }
        public int IdProvincia { get; set; }
        public int IdRegion { get; set; }
        public int IdUserCreate { get; set; }
        public string NombreDistrito { get; set; }
        public SqlGeometry Coordenadas {get;set;}
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
    }
}