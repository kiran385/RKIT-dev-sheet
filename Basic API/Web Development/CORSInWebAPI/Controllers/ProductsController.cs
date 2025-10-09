using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORSInWebAPI.Controllers
{
    //[EnableCors(origins: "https://www.facebook.com/", headers:"*",methods:"*")]
    public class ProductsController : ApiController
    {
        static List<string> list = new List<string>
        {
            "Product1", "Product2", "Product3"
        };

        public IEnumerable<string> Get()
        {
            return list;
        }
    }
}
