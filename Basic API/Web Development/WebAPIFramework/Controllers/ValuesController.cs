using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIFramework.Controllers
{
    [RoutePrefix("api/customvalues")]
    public class ValuesController : ApiController
    {
        static Dictionary<int, string> items = new Dictionary<int, string>()
        {
            {1, "item1" }, { 2, "item2" }, { 3, "item3" }
        };

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(items);
        }

        //This matches numbers in route
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            if (items.ContainsKey(id))
            {
                return Ok($"Value: {items[id]}");
            }
            else
            {
                return Content(HttpStatusCode.NotFound,$"No value found with id {id}");
            }
        }

        //It can match numbers, letters and special character
        [Route("{item}")]
        public IHttpActionResult GetByItem(string item)
        {
            if (items.ContainsValue(item))
            {
                return Ok($"{item} is found");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No item found");
                //return NotFound();
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] KeyValuePair<int, string> kvp)
        {
            try
            {
                items.Add(kvp.Key, kvp.Value);
                string location = $"api/values/{kvp.Key}";
                return Created(location,$"Value {kvp.Value} added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody] string value)
        {
            if (items.ContainsKey(id))
            {
                items[id] = value;
                return Ok($"Value with id {id} updated successfully");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, $"No value found with id {id}");
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (items.ContainsKey(id))
            {
                items.Remove(id);
                return Ok($"Value with id {id} deleted successfully");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, $"No value found with id {id}");
            }
        }
    }
}
