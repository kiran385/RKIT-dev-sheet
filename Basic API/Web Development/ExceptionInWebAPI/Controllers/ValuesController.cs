using System;
using System.Web.Http;

namespace ExceptionHandlingInWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/values")]
        public IHttpActionResult Get()
        {
            // Simulating an error to demonstrate the exception handling filter
            //throw new Exception();

            try
            {
                int zero = 0;
                var result = 1 / zero;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
