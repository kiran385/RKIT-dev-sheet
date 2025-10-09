using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ExceptionHandlingInWebAPI.Handler
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            // Log the exception 
            var exception = context.Exception;

            // Create a response with custom message
            var errorResponse = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new
                {
                    Message = "An unexpected error occurred. Please try again later."
                }
            );

            context.Result = new ResponseMessageResult(errorResponse);
        }
    }
}