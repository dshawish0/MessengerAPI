using Messenger.core.Data;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult authentication([FromBody] Login login)
        {
            var RESULT = loginService.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }
        }

        [HttpPut]
        [Route("restPassword/{loginId}")]
        public IActionResult restPassword([FromBody] Login login)
        {
            return Ok(this.loginService.restPassword(login));
        }

        [HttpPost]
        [Route("getLogByEmail")]
        public IActionResult getLogByEmail([FromBody] Login login)
        {
            return Ok(this.loginService.getLogByEmail(login.Email));
        }
    }
}
