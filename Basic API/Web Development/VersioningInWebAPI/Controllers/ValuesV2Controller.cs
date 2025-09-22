using System.Collections.Generic;
using System.Web.Http;

namespace VersioningInWebAPI.Controllers
{
    public class ValuesV2Controller : ApiController
    {
        static List<string> values = new List<string>()
        {
            "value100","value101","value102"
        };

        //[Route("api/v2/values")]
        public IEnumerable<string> Get()
        {
            return values;
        }

        //[Route("api/v2/values/{id}")]
        public string Get(int id)
        {
            return values[id];
        }
    }
}