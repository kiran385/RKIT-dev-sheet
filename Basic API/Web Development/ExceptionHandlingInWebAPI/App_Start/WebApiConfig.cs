using ExceptionHandlingInWebAPI.Filters;
using ExceptionHandlingInWebAPI.Handler;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ExceptionHandlingInWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Register exception filter
            config.Filters.Add(new ExceptionHandlingFilter());

            // Replace default exception handler with your custom one
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

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
        }
    }
}
