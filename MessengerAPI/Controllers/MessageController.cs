using learn.core.Data;
using learn.core.Service;
using learn.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageservice Messageservice  ;
        public MessageController(IMessageservice Messageservice)
        {
            this.Messageservice = Messageservice;
        }
        [HttpGet]
        [Route("GetAllMessage")]
        public IActionResult GetAllMessage()
        {
            var result = Messageservice.GetAllMessage();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var result = Messageservice.DeleteMessage(id);
            return Ok(result);

        }
        [HttpPost]
        [Route("CreateMessage")]
        public IActionResult CreateMessage([FromBody] Message ins)
        {
            var result = Messageservice.CreateMessage(ins);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpDateMessage")]
        public IActionResult UpDateMessage([FromBody] Message cc)
        {
            var result = Messageservice.UpDateMessage(cc);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMessageById/{id}")]
        public IActionResult GetMessageById(int id)
        {
            var result = Messageservice.GetMessageById(id);
            return Ok(result);
        }
    }
}
