using Microsoft.AspNetCore.Mvc;
using Shares.Models;
using Shares.Repository;

namespace Shares.Controllers
{

    /// <summary>
    /// Controller for user requests.
    /// </summary>
    [Route("Shares-api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        UserRepository repository = new UserRepository();

        /// <summary>
        /// Request to get all users from the database.
        /// 
        /// <c>GET: Shares-api/Users (All users)</c>
        /// </summary>
        /// <returns>Returns all existing users</returns>
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }
        /// <summary>
        /// Request to get user from the database by his id.
        /// 
        /// <c>GET: Shares-api/Users/{userid} (User by his id)</c>
        /// </summary>
        /// <param name="userid">userid which comes from the request</param>
        /// <returns>Returns the selected user</returns>

        [HttpGet("{userid}")]
        public List<User> GetUserByID(int userid)
        {
            return UserRepository.GetUserByID(userid);
        }

        /// <summary>
        /// Request to add a new user to the database.
        /// 
        /// <c>POST: Shares-api/Users</c>
        /// </summary>
        /// <param name="newUser">newUser object which comes from the request with required information</param>
        /// <returns>Returns the added user</returns>

        [HttpPost]
        public User PostNewUser([FromBody] User newUser)
        {
           repository.AddNewUser(newUser);

            return newUser;
        }

        /// <summary>
        /// Request to delete a user from the database.
        /// 
        /// <c>DELETE: Shares-api/Users/{cryptoId}</c>
        /// </summary>
        /// <param name="userid">userid which comes from the request</param>
        /// <returns>Returns all users after deletion</returns>

        [HttpDelete("{userid}")]
        public List<User> DeleteUser(int userid)
        {
            repository.DeleteUser(userid);

            return GetAllUsers();
        }
    }
}