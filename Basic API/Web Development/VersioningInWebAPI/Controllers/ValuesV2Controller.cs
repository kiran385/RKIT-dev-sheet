using System.Collections.Generic;
using System.Web.Http;

namespace VersioningInWebAPI.Controllers
{
    public class ValuesV2Controller : ApiController
    {
        static List<string> values = new List<string>()
        {
            "value100 from V2","value101 from V2","value102 from V2"
        };

        //[Route("api/v2/values")]
        public IEnumerable<string> Get()
        {
            return values;
        }
    }
}