using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System;

namespace HTTPCachingInWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/values")]
        public HttpResponseMessage Get()
        {
            var data = "This is cached data";

            var response = Request.CreateResponse(HttpStatusCode.OK, data);

            // Add Cache-Control header
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromMinutes(10) // Cache duration in minutes
            };

            return response;
        }

        //[HttpGet]
        //[Route("new-values")]
        //public IEnumerable<string> Get()
        //{
        //    return new[] { "value1" };
        //}
    }
}
