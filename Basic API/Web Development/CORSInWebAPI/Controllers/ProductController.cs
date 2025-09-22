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
    public class ProductController : ApiController
    {
        static List<string> list = new List<string>
        {
            "Product1", "Product2", "Product3"
        };

        // GET api/product
        public IEnumerable<string> Get()
        {
            return list;
        }

        // GET api/product/5
        public string Get(int id)
        {
            return list[id];
        }

        // POST api/product
        public void Post([FromBody] string value)
        {
            list.Add(value);
        }

        // PUT api/product/5
        public void Put(int id, [FromBody] string value)
        {
            list[id] = value;
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
            list.RemoveAt(id);  
        }
    }
}
