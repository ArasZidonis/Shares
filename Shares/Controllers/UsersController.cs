using Microsoft.AspNetCore.Mvc;
using Shares.Models;
using Shares.Repository;

namespace Shares.Controllers
{
    [Route("Shares-api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        UserRepository repository = new UserRepository();


        [HttpGet]
        public List<User> Get()
        {
            return UserRepository.GetAllUsers();
        }


        [HttpGet("{userid}")]
        public List<User> GetUserByID(int userid)
        {
            return UserRepository.GetUserByID(userid);
        }


        [HttpPost]
        public User PostNewUser([FromBody] User newUser)
        {
           repository.AddNewUser(newUser);

            return newUser;
        }

        [HttpDelete("{userid}")]
        public List<User> Delete(int userid)
        {
            repository.DeleteUser(userid);

            return Get();
        }
    }
}