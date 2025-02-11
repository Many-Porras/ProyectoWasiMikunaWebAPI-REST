using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[RoutePrefix("api/incidencia")]
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

        [HttpGet]
        [Route("api/incidencia/buscar-por-tipo-numero")]
        public IHttpActionResult GetPorTipoYNumero(string tipoDoc, string nroDoc)
        {
            if (string.IsNullOrEmpty(tipoDoc) || string.IsNullOrEmpty(nroDoc))
                return BadRequest("Debe proporcionar el tipo y número de documento.");

            List<Incidencia> incidencias = IncidenciaData.BuscarPorTipoYNumero(tipoDoc, nroDoc);

            if (incidencias.Count == 0)
                return NotFound();

            return Ok(incidencias);
        }

        [HttpGet]
        [Route("api/incidencia/buscar-por-numero")]
        public IHttpActionResult GetPorNumero(string nroDoc)
        {
            if (string.IsNullOrEmpty(nroDoc))
                return BadRequest("Debe proporcionar el número de documento.");

            List<Incidencia> incidencias = IncidenciaData.BuscarPorNumero(nroDoc);

            if (incidencias.Count == 0)
                return NotFound();

            return Ok(incidencias);
        }
    }
}