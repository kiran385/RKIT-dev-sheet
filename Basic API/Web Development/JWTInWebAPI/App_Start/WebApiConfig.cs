using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JWTInWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Add a route to redirect users to the Swagger UI when accessing the root URL.
            // Swagger provides an interface for testing and exploring the API.
            config.Routes.MapHttpRoute(
                name: "SwaggerRedirect",
                routeTemplate: "", // Matches the root URL of the application.
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(
                    message => message.RequestUri.ToString(),
                    "swagger" // Redirects to the Swagger UI.
                )
            );
        }
    }
}
