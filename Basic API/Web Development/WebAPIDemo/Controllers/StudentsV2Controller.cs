using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// Student controller which contains method for get student data
    /// </summary>
    public class StudentsV2Controller : ApiController
    {
        static List<string> newStudents = new List<string>()
        {
            "NS1", "NS2", "NS3"
        };

        /// <summary>
        /// Get student data from cache if available or send request to server for get fresh data
        /// </summary>
        /// <returns>List of student</returns>
        [Route("api/v2/studentlist")]
        public HttpResponseMessage GetNewStudentList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, newStudents);

            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromMinutes(10) // Cache duration in minutes
            };

            return response;
        }
    }
}
