using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Incidencia
    {
        public int IdIncidencia { get; set; }
        public int IdColegio { get; set; }
        public string TipoIncidencia { get; set; }
        public string Tipologia { get; set; }
        public string TipoDocumentoTutor { get; set; }
        public string NumeroDocumentoTutor { get; set; }
        public string NombreTutor { get; set; }
        public string CelularTutor { get; set; }
        public string DetalleIncidencia { get; set; }
        public byte[] Archivos { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaReagendado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }

        // Relación con la tabla Colegio
        public Colegio Colegio { get; set; }

        // Relación con la tabla DetalleIncidencia
        public List<DetalleIncidencia> DetalleIncidencias { get; set; }
    }
}