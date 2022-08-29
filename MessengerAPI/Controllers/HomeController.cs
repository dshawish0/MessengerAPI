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
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [HttpGet]
        [Route("GetHome")]
        public IActionResult GetHome()
        {
            var result = homeService.GetHome();
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateHome")]
        public IActionResult UpdateHome(Home home)
        {
            var result = homeService.UpdateHome(home);
            return Ok(result);
        }
    }
}
