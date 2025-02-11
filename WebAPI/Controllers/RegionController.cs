using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class RegionController : ApiController
    {
        [HttpGet]
        [Route("api/region/")]
        public List<Region> Get()
        {
            return RegionData.ListarRegion();
        }


    }
}