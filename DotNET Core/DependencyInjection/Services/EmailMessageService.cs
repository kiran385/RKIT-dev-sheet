namespace DependencyInjection.Services
{
    /// <summary>
    /// Email Message service
    /// </summary>
    public class EmailMessageService : IMessageService
    {
        /// <summary>
        /// Get email message
        /// </summary>
        /// <returns>Message</returns>
        public string GetMessage()
        {
            return "Message sent via Email!";
        }
    }
}
