using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        // Habilitar JWT para seguridad de usuario
        public static readonly string JwtSecretKey = "EstaEsUnaClaveSeguraDeMasDe32Caracteres!";
        public static void Register(HttpConfiguration config)
        {
            // Habilitar CORS para el frontend Angular
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
               routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnsureInitialized();

        }
    }
}
