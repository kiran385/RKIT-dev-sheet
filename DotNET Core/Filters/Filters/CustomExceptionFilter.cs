using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    /// <summary>
    /// Custom exception filter
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Define OnException method which called when action throws any exception
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Exception: {context.Exception.Message}");

            context.Result = new JsonResult(new { error = "Custom error occurred" })
            {
                StatusCode = 500
            };
        }
    }
}
