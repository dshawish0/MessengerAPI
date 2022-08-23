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
        private readonly ILoginService loginService;

        public UserController(IUserService userService, ILoginService loginService)
        {
            this.userService = userService;
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserLogDTO userlog)
        {
            var result = userService.InsertUser(userlog);

            userlog.UserId = userService.GetUserByUserName(userlog.userName).UserId;
            loginService.InsertLog(userlog);



            return Ok(result);
        }

        [HttpDelete("DeleteUser/{UserId}")]
        public IActionResult DeleteCourse(int UserId)
        {
            return Ok(userService.DeleteUser(UserId));
        }
        [HttpGet]
        public List<Userr> GetAllUsers()
        {
            return userService.GetAllUsers();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public bool UpdateUser([FromBody] Userr user)
        {
            return userService.UpdateUser(user);
        }
        
        [HttpGet("{id}")]
        public Userr course(int userId)
        {
            return userService.GetUserById(userId);
        }
        
        [HttpPost]
        [Route("GetUserByUserName/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                var result = userService.GetUserByUserName(userName);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("IsBlocked")]
        public IActionResult IsBlocked([FromBody] Userr user)
        {
            try
            {
                var result = userService.IsBlocked(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("UnBlocked")]
        public IActionResult UnBlock(Userr user)
        {
            try
            {
                var result = userService.UnBlock(user);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
