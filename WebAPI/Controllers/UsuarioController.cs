using System.Collections.Generic;
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
        // GET api/<controller>
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }

        // GET api/<controller>/5
        public Usuario Get(int id)
        {
            return UsuarioData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Registrar(oUsuario);
        }

        //// PUT api/<controller>/5
        public bool Put([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Modificar(oUsuario);
        }

        //// DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return UsuarioData.Eliminar(id);
        }
    }
}