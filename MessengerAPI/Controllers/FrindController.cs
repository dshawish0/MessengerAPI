using learn.core.Data;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrindController : ControllerBase
    {
        private readonly IFrindService frindService;

        public FrindController(IFrindService frindService)
        {
            this.frindService = frindService;
        }
        [HttpGet]
        [Route("GetFrinds/{userId}")]
        public IActionResult GetFrinds(int userId)
        {
            try
            {
                var result = frindService.GetAllFrinds(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetFrindById")]
        public IActionResult GetFrindById([FromBody] Frinds frind)
        {
            try
            {
                var result = frindService.GetFrindById((int)frind.User_Id, frind.Userreceiveid);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("AddFrind")]
        public IActionResult AddFrind([FromBody] Frinds frind)
        {
            try
            {
                frindService.AddFrind(frind);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("UpDateFrind")]
        public IActionResult UpDateFrind([FromBody] Frinds frind)
        {
            try
            {
                frindService.UpdateFrind(frind);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteFrind")]
        public IActionResult DeleteFrind([FromBody] Frinds frind)
        {
            try
            {
                frindService.DeleteFrind((int)frind.User_Id, frind.Userreceiveid);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
