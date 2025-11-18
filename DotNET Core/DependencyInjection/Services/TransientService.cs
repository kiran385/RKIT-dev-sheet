namespace DependencyInjection.Services
{
    /// <summary>
    /// Overrides ILifetimeService properties
    /// </summary>
    public class TransientService : ILifetimeService
    {
        /// <summary>
        /// Unique id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();
    }
}
