using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserLogDTO userlog)
        {
            var result = userService.InsertUser(userlog);
            Console.WriteLine(userlog.UserId);
            Console.WriteLine(userlog.User_Id);

            Login log = new Login();
            log.Email = userlog.Email;
            log.Password = userlog.Password;
            log.User_Id = userlog.User_Id;

            return Ok(result);
        }
    }
}
