using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPIDemo
{
    /// <summary>
    /// Contains route details and global CORS setting
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Configures routing and global CORS. This method is called at application startup
        /// </summary>
        /// <param name="config">The HTTP configuration object</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SwaggerRedirect",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger")
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("http://127.0.0.1:5500", "*", "*");
            config.EnableCors(cors);
        }
    }
}
