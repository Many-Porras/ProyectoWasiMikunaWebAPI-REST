using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/usuario/login")]
        public IHttpActionResult Login([FromBody] Usuario usuario)
        {
            var user = UsuarioData.LoginUsuario(usuario.Email, usuario.Password);
            if (user == null)
                return BadRequest("Correo o contraseña incorrectos");

            return Ok(user);
        }

        //Metodo para generar token
        private string GenerarToken(Usuario usuario)
        {
            var key = Encoding.UTF8.GetBytes(WebApiConfig.JwtSecretKey);
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
        new Claim(ClaimTypes.Email, usuario.Email),
        new Claim(ClaimTypes.Name, usuario.Name)
    };

            var credenciales = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "tu_api",
                audience: "tu_api",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost]
        [Route("api/usuario/loginJWT")]
        public IHttpActionResult LoginJWT([FromBody] Usuario usuario)
        {
            var user = UsuarioData.LoginUsuarioJWT(usuario.Email, usuario.Password);
            if (user == null)
                return BadRequest("Correo o contraseña incorrectos");

            var token = GenerarToken(user);
            return Ok(new { token, user });
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult RefreshToken()
        {
            var userId = User.Identity.Name;
            var newToken = GenerarToken(new Usuario { IdUsuario = int.Parse(userId) });
            return Ok(new { token = newToken });
        }

    }
}