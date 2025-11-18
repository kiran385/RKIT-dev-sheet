using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    /// <summary>
    /// Created custom filter for authorization logic
    /// </summary>
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Overrides OnAuthorization method to write authorization logic
        /// </summary>
        /// <param name="context">A context for authorization filter</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = true;
            if(!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
