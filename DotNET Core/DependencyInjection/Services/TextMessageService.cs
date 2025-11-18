namespace DependencyInjection.Services
{
    /// <summary>
    /// Test Message service
    /// </summary>
    public class TextMessageService : IMessageService
    {
        /// <summary>
        /// Get text message
        /// </summary>
        /// <returns>Message</returns>
        public string GetMessage()
        {
            return "Message sent via Text!";
        }
    }
}
