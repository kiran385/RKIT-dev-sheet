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
            throw new Exception();

            // Exception handling using try catch block
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
