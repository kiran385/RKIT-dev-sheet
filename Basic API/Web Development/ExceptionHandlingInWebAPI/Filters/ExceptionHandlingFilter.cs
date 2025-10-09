using System.Net;
using System.Web.Http.Filters;
using System.Net.Http;

namespace ExceptionHandlingInWebAPI.Filters
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // Log the exception
            var exception = context.Exception;

            context.Response = context.Request.CreateErrorResponse(
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred. Please try again later."
            );
        }
    }
}