using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    // Habilitar CORS para solicitudes desde Angular (localhost:4200)
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DetalleIncidenciaController : ApiController
    {
        // GET api/<controller>
        public List<DetalleIncidencia> Get()
        {
            return DetalleIncidenciaData.Listar();
        }

        // GET api/<controller>/5
        public DetalleIncidencia Get(int id)
        {
            return DetalleIncidenciaData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] DetalleIncidencia oDetalleIncidencia)
        {
            return DetalleIncidenciaData.Registrar(oDetalleIncidencia);
        }

        //// PUT api/<controller>/5
        public bool Put([FromBody] DetalleIncidencia oDetalleIncidencia)
        {
            return DetalleIncidenciaData.Modificar(oDetalleIncidencia);
        }

        //// DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return DetalleIncidenciaData.Eliminar(id);
        }
    }
}