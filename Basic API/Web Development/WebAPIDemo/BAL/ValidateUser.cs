using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.BAL
{
    /// <summary>
    /// ValidateUser class contains method for user credential validation
    /// </summary>
    public class ValidateUser
    {
        /// <summary>
        /// Validate user credentials
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>Role of user</returns>
        public static string ValidateUserCredentials(string username, string password)
        {
            if (username == "admin" && password == "string")
                return "Admin";
            if (username == "user" && password == "string")
                return "User";

            return null;
        }
    }
}