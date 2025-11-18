namespace DependencyInjection.Services
{
    /// <summary>
    /// Interface for message service
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Message method
        /// </summary>
        /// <returns>Message</returns>
        string GetMessage();
    }
}
