using System.Net;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Net.Http;

namespace ExceptionInWebAPI.ExceptionHandling
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
                    Message = "An unexpected error occurred. Please try again later.",
                    ExceptionMessage = exception.Message
                });

            context.Result = new ResponseMessageResult(errorResponse);
        }
    }
}