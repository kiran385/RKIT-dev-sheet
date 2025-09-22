﻿using JWTInWebAPI.Handler;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JWTInWebAPI.Filters
{
    // A custom authorization filter that validates JWT tokens and checks user roles.
    public class JWTAuthorizationFilter : AuthorizationFilterAttribute
    {
        private readonly string[] _allowedRoles;

        // Initializes the JWTAuthorizationFilter with the allowed roles.
        public JWTAuthorizationFilter(params string[] roles)
        {
            _allowedRoles = roles;
        }

        // Checks the presence and validity of the JWT token and validates user roles.
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the Authorization header is present
            if (actionContext.Request.Headers.Authorization == null ||
                string.IsNullOrWhiteSpace(actionContext.Request.Headers.Authorization.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Missing or invalid token.");
                return;
            }
            string token = actionContext.Request.Headers.Authorization.Parameter;

            try
            {
                ClaimsPrincipal principal = JWTHandler.ValidateJwtToken(token);
                // Validate the JWT token
                if (principal == null)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid or expired token.");
                    return;
                }
                    
                // Extract role from the token
                string userRole = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                if (string.IsNullOrEmpty(userRole))
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Role information missing in token.");
                    return;
                }

                // Check if the user's role is allowed
                if (_allowedRoles != null && _allowedRoles.Length > 0 && !_allowedRoles.Contains(userRole, StringComparer.OrdinalIgnoreCase))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "Access denied.");
                    return;
                }

            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, $"Invalid token. Error: {ex.Message}");
            }
        }
    }
}