using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIFramework.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        static Dictionary<int, string> items = new Dictionary<int, string>()
        {
            {1, "item1" }, { 2, "item2" }, { 3, "item3" }
        };

        // GET api/values
        [Route("")]
        public IEnumerable<KeyValuePair<int,string>> Get()
        {
            return items;
        }

        // GET api/values/1
        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            if(items.ContainsKey(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Value: " + items[id]);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No value found with id " + id);
            }
        }

        [Route("{item}")]
        public IHttpActionResult Get(string item)
        {
            if(items.ContainsValue(item))
            {
                return Ok($"{item} is found");
                //return Request.CreateResponse(HttpStatusCode.OK, $"{item} is found");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No item found");
                //return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No item found");
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] KeyValuePair<int,string> kvp)
        {
            try
            {
                items.Add(kvp.Key,kvp.Value);

                var message = Request.CreateResponse(HttpStatusCode.Created, kvp.Value);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + kvp.Key.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/values/1
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            if (items.ContainsKey(id))
            {
                items[id] = value;
                return Request.CreateResponse(HttpStatusCode.OK, $"Value with id {id} updated successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No value found with id " + id);
            }
        }

        // DELETE api/values/1
        public HttpResponseMessage Delete(int id)
        {
            if(items.ContainsKey(id))
            {
                items.Remove(id);
                return Request.CreateResponse(HttpStatusCode.OK, $"Value with id {id} deleted successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No value found with id " + id);
            }
        }
    }
}
