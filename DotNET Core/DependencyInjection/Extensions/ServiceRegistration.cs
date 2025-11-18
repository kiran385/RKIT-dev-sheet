using DependencyInjection.Services;

namespace DependencyInjection.Extensions
{
    /// <summary>
    /// Class for registering different services
    /// </summary>
    public static class ServiceRegistration
    {
        /// <summary>
        /// Extension method for registering services
        /// </summary>
        /// <param name="services">Services</param>
        /// <returns>Collection of services</returns>
        public static IServiceCollection MyServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageService, EmailMessageService>();
            services.AddTransient<IMessageService, TextMessageService>();

            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();
            services.AddSingleton<SingletonService>();

            return services;
        }
    }
}
