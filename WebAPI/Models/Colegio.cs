using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Colegio
    {
        public int IdColegio { get; set; }
        public int IdDistrito { get; set; }
        public string CodigoModular { get; set; }
        public string NombreColegio { get; set; }
        public string TelefonoColegio { get; set; }
        public string DireccionColegio { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }

        // Relación con la tabla Incidencia

    }
}