using System.Collections.Generic;
using System.Web.Http;

namespace VersioningInWebAPI.Controllers
{
    public class ValuesV1Controller : ApiController
    {
        static List<string> values = new List<string>()
        {
            "value0","value1","value2"
        };

        //[Route("api/v1/values")]
        public IEnumerable<string> Get()
        {
            return values;
        }
    }
}
