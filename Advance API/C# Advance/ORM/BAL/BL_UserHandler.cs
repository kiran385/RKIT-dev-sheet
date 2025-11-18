using ORM.MAL.DTO;
using ORM.MAL.POCO;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace ORM.BAL
{
    /// <summary>
    /// Contains methods which executes different orm lite queries
    /// </summary>
    public class BL_UserHandler
    {
        /// <summary>
        /// Declare IDbConnectionFactory instance
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// BL_UserHandler constuctor
        /// </summary>
        /// <exception cref="Exception">Exception message</exception>
        public BL_UserHandler() 
        {
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

            //Checking if connection is their or not
            if (_dbFactory == null)
            {
                throw new Exception("IDbConnectionFactory not found");
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        public List<User01> GetAll()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Select<User01>();
            }
        }

        /// <summary>
        /// Get user by its id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>User data</returns>
        public User01 Get(long id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<User01>(id);
            }
        }

        /// <summary>
        /// Check if user is present in database or not
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>Boolean message is user exist or not</returns>
        public bool CheckExists(long id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Exists<User01>(u => u.Id == id);
            }
        }

        /// <summary>
        /// Count all user of database table
        /// </summary>
        /// <returns>Count of users</returns>
        public long GetCount()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Count<User01>();
            }
        }

        /// <summary>
        /// Get list of all valid emails
        /// </summary>
        /// <returns>List of emails</returns>
        public List<string> GetValidEmail()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                SqlExpression<User01> subQuery = db.From<User01>()
                                            .Where(u => u.Email.Contains("@"))
                                            .Select(u => u.Email);
                SqlExpression<User01> mainQuery = db.From<User01>()
                                                .Where(u => Sql.In(u.Email, subQuery))
                                                .Select(u => u.Email);
                List<string> users = db.Column<string>(mainQuery);
                return users;
            }
        }

        /// <summary>
        /// Get names of all users
        /// </summary>
        /// <returns>List of names</returns>
        public List<string> GetUserNames()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                SqlExpression<User01> expression = db.From<User01>().Select("UserName");
                List<string> names = db.Select<string>(expression);
                return names;
            }
        }

        /// <summary>
        /// Add new user to database table
        /// </summary>
        /// <param name="dtoUser">User data</param>
        /// <returns>Added user data</returns>
        public User01 Add(DTO_User01 dtoUser)
        {
            User01 user = dtoUser.Convert<User01>();
            user.LoggedTime = DateTime.Now;
            long insertId;
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                insertId = db.Insert(user, selectIdentity: true);
            }
            return Get(insertId);
        }

        /// <summary>
        /// Add multiple users to database table
        /// </summary>
        /// <param name="dtoUsers">User data</param>
        /// <returns>Count of added users</returns>
        public int AddAll(List<DTO_User01> dtoUsers)
        {
            List<User01> users = dtoUsers.ConvertAll(dto =>
            {
                User01 user = dto.Convert<User01>();
                user.LoggedTime = DateTime.Now;
                return user;
            });
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.InsertAll(users);
            }
            return users.Count;
        }

        /// <summary>
        /// Add userName to database table
        /// </summary>
        /// <param name="dtoUser">User data</param>
        public void AddUserNameOnly(DTO_User01 dtoUser)
        {
            User01 user = dtoUser.Convert<User01>();
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.InsertOnly(new User01 { UserName = user.UserName }, u => u.UserName);
            }
        }

        /// <summary>
        /// Remove user by its id from database
        /// </summary>
        /// <param name="id">User id</param>
        public void Remove(long id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.DeleteById<User01>(id);
            }
        }

        /// <summary>
        /// Delete all user data
        /// </summary>
        /// <returns>Count of deleted users</returns>
        public int RemoveAll()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                int rowsDeleted = db.DeleteAll<User01>();
                return rowsDeleted;
            }
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="dtoUser">New data of user</param>
        /// <returns>Updated user data</returns>
        public User01 Update(DTO_User01 dtoUser)
        {
            User01 user = dtoUser.Convert<User01>();
            user.LoggedTime = DateTime.Now;
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.Update(user);
            }
            return user;
        }

        /// <summary>
        /// Update only userName
        /// </summary>
        /// <param name="dtoUser">New data of user</param>
        public void UpdateUserNameOnly(DTO_User01 dtoUser)
        {
            User01 user = dtoUser.Convert<User01>();
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.UpdateOnly(() => new User01 { UserName = user.UserName });
            }
        }
    }
}