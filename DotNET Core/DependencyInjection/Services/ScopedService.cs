namespace DependencyInjection.Services
{
    /// <summary>
    /// Overrides ILifetimeService properties
    /// </summary>
    public class ScopedService : ILifetimeService
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
