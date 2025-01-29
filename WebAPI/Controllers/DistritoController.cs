using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DistritoController : ApiController
    {
        [HttpGet]
        [Route("api/distrito/{id_provincia?}")]
        public IHttpActionResult GetDistritosPorProvincia(int? id_provincia)
        {
            if (id_provincia == null)
            {
                return BadRequest("El parámetro id_provincia es requerido.");
            }

            var distritos = DistritoData.ListarDistritosPorProvincia(id_provincia.Value);
            if (distritos == null || distritos.Count == 0)
                return NotFound();

            return Ok(distritos);
        }

        [HttpGet]
        [Route("api/distrito/por-coordenadas")]
        public IHttpActionResult GetDistritoPorCoordenadas(double longitud, double latitud)
        {
            var distrito = DistritoData.ObtenerDistritoPorCoordenadas(longitud, latitud);

            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }
    }
}