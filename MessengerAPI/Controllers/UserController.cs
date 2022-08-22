using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail([FromBody] Userr user)
        {
            try
            {
                var result = userService.GetUserByUserName(user.userName);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpGet]
        [Route("ConfirmEmail/{code}")]
        public IActionResult confirmEmail(string code)
        {
            return Ok(userService.confirmEmail(code));
        }

        [HttpPost]
        [Route("upLoadImg")]
        public Userr UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = Path.Combine("D:\\MessengerAppUI\\MessengerAppUI\\src\\assets\\Img", fileName);

                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Userr item = new Userr();
                item.ProFileImg = fileName;
                return item;
            }
            catch(Exception e)
            {
                return null;


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
