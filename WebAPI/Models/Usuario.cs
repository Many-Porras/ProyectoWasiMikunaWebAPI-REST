using System;

namespace WebAPI.Models
{
    public class Usuario
    {
        public long IdUsuario { get; set; }
        public string Name { get; set; }
        public string TipDoc { get; set; }
        public string NroDoc { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public string EmailVerifiedAt { get; set; }
        public string NameUse { get; set; }
    }
}
