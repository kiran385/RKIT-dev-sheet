namespace WebAPIDemo.Models
{
    /// <summary>
    /// Login modal with username and password
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Username of user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; set; }
    }
}