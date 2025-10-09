using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace AuthenticationInWebAPI.Filters
{
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Allow anonymous access if the action has the AllowAnonymousAttribute applied
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count > 0)
            {
                return;
            }

            // Retrieve the Authorization header from the request
            AuthenticationHeaderValue authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null || authHeader.Scheme != "Basic")
            {
                // Handle unauthorized access if no valid Basic Authentication header is found
                HandleUnauthorized(actionContext);
                return;
            }

            try
            {
                // Decode the Base64-encoded credentials from the Authorization header
                string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter));
                string[] parts = credentials.Split(':');

                // Ensure that the credentials are properly formatted (username:password)
                if (parts.Length != 2)
                {
                    HandleUnauthorized(actionContext);
                    return;
                }

                string username = parts[0];
                string password = parts[1];

                // Validate the user credentials and retrieve associated roles
                if (!IsAuthorizedUser(username, password, out string[] roles))
                {
                    HandleUnauthorized(actionContext);
                    return;
                }

                // Create and set the Principal for the authenticated user
                GenericIdentity identity = new GenericIdentity(username);
                GenericPrincipal principal = new GenericPrincipal(identity, roles);
                Thread.CurrentPrincipal = principal;

                // Also set the Principal for the current HTTP context
                if (System.Web.HttpContext.Current != null)
                {
                    System.Web.HttpContext.Current.User = principal;
                }
            }
            catch (FormatException)
            {
                // Handle malformed Authorization header
                HandleUnauthorized(actionContext);
            }
        }

        private bool IsAuthorizedUser(string username, string password, out string[] roles)
        {
            roles = null;

            // User database
            var users = new[]
            {
                new { Username = "admin", Password = "password", Roles = new[] { "Admin" } },
                new { Username = "user", Password = "password", Roles = new[] { "User" } }
            };

            // Find a matching user in the database
            var user = Array.Find(users, u => u.Username == username && u.Password == password);

            if (user != null)
            {
                roles = user.Roles; // Assign roles if the user is authenticated
                return true;
            }

            return false; // Authentication failed
        }

        // Handles unauthorized requests by returning a 401 Unauthorized response.
        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"localhost\"");
        }
    }
}