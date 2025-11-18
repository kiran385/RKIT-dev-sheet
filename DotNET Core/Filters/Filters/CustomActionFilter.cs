using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    /// <summary>
    /// Created custom action filter
    /// </summary>
    public class CustomActionFilter : Attribute, IActionFilter
    {
        /// <summary>
        /// Called before the action executes, after model binding is complete
        /// </summary>
        /// <param name="context">The context of the action executing</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Called Before - Action");
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The context of the action executed</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Called After - Action");
        }
    }
}
