using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProvinciaController : ApiController
    {
        [HttpGet]
        [Route("api/provincia/{id_region?}")]
        public IHttpActionResult GetProvinciasPorRegion(int? id_region)
        {
            if (id_region == null)
            {
                return BadRequest("El parámetro id_region es requerido.");
            }

            var provincias = ProvinciaData.ObtenerProvinciasPorRegion(id_region.Value);
            if (provincias == null || provincias.Count == 0)
                return NotFound();

            return Ok(provincias);
        }



    }
}