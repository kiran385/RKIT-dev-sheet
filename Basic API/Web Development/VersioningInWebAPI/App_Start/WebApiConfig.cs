using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using VersioningInWebAPI.Custom;

namespace VersioningInWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SwaggerRedirect",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger")
            );

            // Convension based URI versioning
            //config.Routes.MapHttpRoute(
            //    name: "Version1",
            //    routeTemplate: "api/v1/values/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "ValuesV1" }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "Version2",
            //    routeTemplate: "api/v2/values/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "ValuesV2" }
            //);

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));
        }
    }
}
