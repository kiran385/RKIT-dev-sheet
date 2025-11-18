using ORM.BAL;
using ORM.MAL.POCO;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using ORM.MAL.DTO;

namespace ORM.API
{
    /// <summary>
    /// User controller for all methods
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Instance of class BL_UserHandler
        /// </summary>
        private BL_UserHandler _objUserHandler = new BL_UserHandler();

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route("get_all_users")]
        public IHttpActionResult GetAllUsers()
        {
            List<User01> users = _objUserHandler.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Get user by its id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>User data</returns>
        [HttpGet]
        [Route("get_user/{id}")]
        public IHttpActionResult GetUserById(long id)
        {
            User01 user = _objUserHandler.Get(id);
            if(user == null)
            {
                return Content(HttpStatusCode.NotFound, $"User with id {id} is not found");
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// Check if user is present in database or not
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>Message if user exist or not</returns>
        [HttpGet]
        [Route("check_user_exist/{id}")]
        public IHttpActionResult IsUserExists(long id)
        {
            bool ifExist = _objUserHandler.CheckExists(id);
            if (ifExist)
            {
                return Content(HttpStatusCode.OK, "User exist!!");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "User not exist!!");
            }
        }

        /// <summary>
        /// Count all user of database table
        /// </summary>
        /// <returns>Count of users</returns>
        [HttpGet]
        [Route("get_user_count")]
        public IHttpActionResult GetUserCount()
        {
            long totalUsers = _objUserHandler.GetCount();
            return Content(HttpStatusCode.OK, $"Total users: {totalUsers}");
        }

        /// <summary>
        /// Get list of all valid emails
        /// </summary>
        /// <returns>List of emails</returns>
        [HttpGet]
        [Route("get_valid_email")]
        public IHttpActionResult GetValidEmail()
        {
            List<string> emails = _objUserHandler.GetValidEmail();
            return Ok(emails);
        }

        /// <summary>
        /// Get names of all users
        /// </summary>
        /// <returns>List of names</returns>
        [HttpGet]
        [Route("get_user_names")]
        public IHttpActionResult GetUserNames()
        {
            List<string> userNames = _objUserHandler.GetUserNames();
            return Ok(userNames);
        }

        /// <summary>
        /// Add new user to database table
        /// </summary>
        /// <param name="dtoUser">User data</param>
        /// <returns>Added user data</returns>
        [HttpPost]
        [Route("add_user")]
        public IHttpActionResult AddUser(DTO_User01 dtoUser)
        {
            User01 user = _objUserHandler.Add(dtoUser);
            return Content(HttpStatusCode.Created,user);
        }

        /// <summary>
        /// Add multiple users to database table
        /// </summary>
        /// <param name="dtoUsers">User data</param>
        /// <returns>Count of added users</returns>
        [HttpPost]
        [Route("add_multiple_users")]
        public IHttpActionResult AddMultipleUsers(List<DTO_User01> dtoUsers)
        {
            long addedUsers = _objUserHandler.AddAll(dtoUsers);
            return Content(HttpStatusCode.Created, addedUsers);
        }

        /// <summary>
        /// Add userName to database table
        /// </summary>
        /// <param name="dtoUser">User data</param>
        /// <returns>Ok message</returns>
        [HttpPost]
        [Route("add_user_name_only")]
        public IHttpActionResult AddUserNameOnly(DTO_User01 dtoUser)
        {
            _objUserHandler.AddUserNameOnly(dtoUser);
            return Ok();
        }

        /// <summary>
        /// Delete user by its id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>Appropriate message if user deleted or not</returns>
        [HttpDelete]
        [Route("delete_user/{id}")]
        public IHttpActionResult DeleteUserById(long id)
        {
            User01 user = _objUserHandler.Get(id);
            if(user == null)
            {
                return Content(HttpStatusCode.NotFound, $"User with id {id} is not found");
            }
            else
            {
                _objUserHandler.Remove(id);
                return Content(HttpStatusCode.OK, $"User with id {id} is deleted successfully");
            }
        }

        /// <summary>
        /// Delete all user data
        /// </summary>
        /// <returns>Appropriate message if user deleted or not</returns>
        [HttpDelete]
        [Route("delete_all_users")]
        public IHttpActionResult DeleteAll()
        {
            int rowsAffected = _objUserHandler.RemoveAll();
            if(rowsAffected > 0)
            {
                return Content(HttpStatusCode.OK, "All users data cleared");
            }
            else
            {
                return Content(HttpStatusCode.NotFound, "No user data found!!");
            }
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="dtoUser">New data of user</param>
        /// <returns>Appropriate message if user updated or not</returns>
        [HttpPut]
        [Route("update_user")]
        public IHttpActionResult UpdateUser(DTO_User01 dtoUser)
        {
            User01 user = _objUserHandler.Get(dtoUser.Id);
            if(user == null)
            {
                return Content(HttpStatusCode.NotFound, $"User with id {dtoUser.Id} is not found");
            }
            else
            {
                User01 updatedUser = _objUserHandler.Update(dtoUser);
                return Content(HttpStatusCode.Created, updatedUser);
            }
        }

        /// <summary>
        /// Update only userName
        /// </summary>
        /// <param name="dtoUser">New data of user</param>
        /// <returns>Ok message</returns>
        [HttpPut]
        [Route("update_user_name_only")]
        public IHttpActionResult UpdateUserNameOnly(DTO_User01 dtoUser)
        {
            _objUserHandler.UpdateUserNameOnly(dtoUser);
            return Ok();
        }
    }
}
