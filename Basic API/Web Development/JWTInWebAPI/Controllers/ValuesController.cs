using JWTInWebAPI.Filters;
using System.Web.Http;

namespace JWTInWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/secure/data")]
        [JWTAuthorizationFilter]
        public IHttpActionResult GetData()
        {
            return Ok("This is secured data.");
        }
    }
}
