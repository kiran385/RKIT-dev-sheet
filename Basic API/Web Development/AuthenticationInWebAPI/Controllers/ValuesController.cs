﻿using AuthenticationInWebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationInWebAPI.Controllers
{
    //[BasicAuthenticationFilter]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [Authorize(Roles = "admin,user")]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("admin")]
        [Authorize(Roles = "admin")]
        public IEnumerable<string> GetAdminData()
        {
            return new string[] { "admin1", "admin2" };
        }
        
        [Route("user")]
        [Authorize(Roles = "user")] 
        public IEnumerable<string> GetUserData()
        {
            return new string[] { "user1", "user2" };
        }
    }
}
