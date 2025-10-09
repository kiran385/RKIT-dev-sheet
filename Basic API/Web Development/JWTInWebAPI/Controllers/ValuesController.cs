using JWTInWebAPI.Filters;
using System.Web.Http;

namespace JWTInWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [JWTAuthorizationFilter]
        [HttpGet]
        [Route("api/secure/data")]
        public IHttpActionResult GetData()
        {
            return Ok("This is secured data.");
        }
    }
}
