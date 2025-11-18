using ServiceStack.DataAnnotations;
using System;

namespace ORM.MAL.POCO
{
    /// <summary>
    /// Represent User01 table in database
    /// </summary>
    public class User01
    {
        /// <summary>
        /// User Id
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Unique]
        public string Email { get; set; }

        /// <summary>
        /// User loggedIn time
        /// </summary>
        public DateTime LoggedTime { get; set; }
    }
}