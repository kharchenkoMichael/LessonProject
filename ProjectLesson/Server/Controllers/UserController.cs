using BussinesLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{phone}/{password}")]
        public User? Login(string phone,string password)
        {
           return _userService.Login(phone,password);
 
        }
    
        [HttpGet("{phoneNumber}")]
        public User? GetUserByPhone(string phoneNumber)
        {
            return _userService.GetUserByPhone(phoneNumber);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser([FromBody]User user)
        {
            _userService.UpdateUser(user);
            return Ok();
        }
    }
}

