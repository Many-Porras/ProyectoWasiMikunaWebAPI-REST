using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CentroSaludController : ApiController
    {
        // GET api/<controller>
        public List<CentroSalud> Get()
        {
            return CentroSaludData.Listar();
        }

        // GET api/<controller>/5
        public CentroSalud Get(int id)
        {
            return CentroSaludData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] CentroSalud oCentroSalud)
        {
            return CentroSaludData.Registrar(oCentroSalud);
        }

        //// PUT api/<controller>/5
        public bool Put([FromBody] CentroSalud oCentroSalud)
        {
            return CentroSaludData.Modificar(oCentroSalud);
        }

        //// DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return CentroSaludData.Eliminar(id);
        }
    }
}