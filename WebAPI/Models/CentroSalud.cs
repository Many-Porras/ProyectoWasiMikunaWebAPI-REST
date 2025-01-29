using System;

namespace WebAPI.Models
{
    public class CentroSalud
    {
        public int IdCentroSalud { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Distrito { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
    }
}