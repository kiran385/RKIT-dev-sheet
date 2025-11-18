using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    /// <summary>
    /// Custom Result filter
    /// </summary>
    public class CustomResultFilter : Attribute, IResultFilter
    {
        /// <summary>
        /// Called before the action result executes
        /// </summary>
        /// <param name="context">The context of the result executing</param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Called Before - Result");
        }

        /// <summary>
        /// Called after the action result executes
        /// </summary>
        /// <param name="context">The context of the result executed</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Called After - Result");
        }
    }
}
