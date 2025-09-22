﻿using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebAPI.Custom
{
    // Derive from the DefaultHttpControllerSelector class
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // Get all the available Web API controllers
            var controllers = GetControllerMapping();
            // Get the controller name and parameter values from the request URI
            var routeData = request.GetRouteData();

            // Get the controller name from route data.
            var controllerName = "Values";

            // Default version number to 1
            string versionNumber = "1";
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString["v"] != null)
            {
                versionNumber = versionQueryString["v"];
            }


            // custom header versioning
            //string customHeader = "X-ValueService-Version";
            //if (request.Headers.Contains(customHeader))
            //{
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //}


            if (versionNumber == "1")
            {
                // if version number is 1, then append V1 to the controller name.
                controllerName = controllerName + "V1";
            }
            else
            {
                // if version number is 2, then append V2 to the controller name.
                controllerName = controllerName + "V2";
            }

            HttpControllerDescriptor controllerDescriptor;
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            return null;
        }
    }
}