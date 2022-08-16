using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageGroupController : ControllerBase
    {
        private readonly IMessageGroupservice MessageGroupservice ;
        public MessageGroupController(IMessageGroupservice MessageGroupservice)
        {
            this.MessageGroupservice = MessageGroupservice;
        }
        [HttpGet]
        [Route("GetAllMessageGroup")]
        public IActionResult GetAllMessageGroup()
        {
            var result = MessageGroupservice.GetAllMessageGroup();
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteMessageGroup/{id}")]
        public IActionResult DeleteMessageGroup(int id)
        {
            var result = MessageGroupservice.DeleteMessageGroup(id);
            return Ok(result);

        }
        [HttpPost]
        [Route("CreateMessageGroup")]
        public IActionResult MessageGroup([FromBody] MessageGroup cc)
        {
            var result = MessageGroupservice.CreateMessageGroup(cc);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpDateMessageGroup")]
        public IActionResult UpDateMessageGroup([FromBody] MessageGroup cc)
        {
            var result = MessageGroupservice.UpDateMessageGroup(cc);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMessageGroupById/{id}")]
        public IActionResult GetMessageGroupById(int id)
        {
            var result = MessageGroupservice.GetMessageGroupById(id);
            return Ok(result);
        }
    }
}
