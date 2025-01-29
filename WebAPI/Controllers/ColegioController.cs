using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ColegioController : ApiController
    {
        [HttpGet]
        [Route("api/colegio/{id_distrito?}")]
        public IHttpActionResult GetColegiosPorDistrito(int? id_distrito)
        {
            if (id_distrito == null)
            {
                return BadRequest("El parámetro id_distrito es requerido.");
            }

            var colegios = ColegioData.ListarColegiosPorDistrito(id_distrito.Value);
            if (colegios == null || colegios.Count == 0)
                return NotFound();

            return Ok(colegios);
        }

    }
}