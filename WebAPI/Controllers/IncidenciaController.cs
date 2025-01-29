using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class IncidenciaController : ApiController
    {
        [HttpPost]
        [Route("api/incidencia/registrar")]
        public IHttpActionResult Post([FromBody] Incidencia oIncidencia)
        {
            if (oIncidencia == null)
                return BadRequest("Datos de incidencia inválidos.");

            int idGenerado = IncidenciaData.RegistrarIncidencia(oIncidencia);

            if (idGenerado > 0)
                return Ok(new { IdGenerado = idGenerado });

            return InternalServerError(new System.Exception("No se pudo insertar la incidencia."));
        }


        // GET api/<controller>/5
        public Incidencia Get(int id)
        {
            return IncidenciaData.Obtener(id);
        }

    }
}