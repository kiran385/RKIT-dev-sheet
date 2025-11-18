namespace DependencyInjection.Services
{
    /// <summary>
    /// Interface for service lifetime
    /// </summary>
    public interface ILifetimeService
    {
        /// <summary>
        /// Unique id
        /// </summary>
        Guid Id { get; }
    }
}
