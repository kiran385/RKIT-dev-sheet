using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Filters.Filters
{
    /// <summary>
    /// Created custom resource filter
    /// </summary>
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        /// <summary>
        /// Override OnResourceExecuting method which called before the remainder of the pipeline
        /// </summary>
        /// <param name="context">The context of the resource executing</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Called Before - Resource");
        }

        /// <summary>
        /// Override OnResourceExecuting method which called after the remainder of the pipeline
        /// </summary>
        /// <param name="context">The context of the resource executed</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Called After - Resource");
        }
    }
}
