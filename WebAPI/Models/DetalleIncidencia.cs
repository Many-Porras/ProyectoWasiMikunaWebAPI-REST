using System;

namespace WebAPI.Models
{
    public class DetalleIncidencia
    {
        public int IdDetalleIncidencia { get; set; }
        public int IdIncidencia { get; set; }
        public int IdUsuario { get; set; }
        public string DetalleIncidenciaTexto { get; set; }
        public string Comentario { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }

        // Relaciones con las tablas Incidencia y Usuario
        public Incidencia Incidencia { get; set; }
        public Usuario Usuario { get; set; }
    }
}