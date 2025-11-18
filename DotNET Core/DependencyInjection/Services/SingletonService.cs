namespace DependencyInjection.Services
{
    /// <summary>
    /// Overrides ILifetimeService properties
    /// </summary>
    public class SingletonService : ILifetimeService
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
