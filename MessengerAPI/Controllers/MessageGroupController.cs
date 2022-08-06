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
        public List<MessageGroup> GetAllMessageGroup()
        {
            return MessageGroupservice.GetAllMessageGroup();
        }
        [HttpDelete]
        [Route("DeleteMessageGroup/{id}")]
        public string DeleteMessageGroup(int id)
        {
            return MessageGroupservice.DeleteMessageGroup(id);

        }
        [HttpPost]
        [Route("CreateMessageGroup")]
        public string MessageGroup([FromBody] MessageGroup cc)
        {
            return MessageGroupservice.CreateMessageGroup(cc);  
        }

        [HttpPut]
        [Route("UpDateMessageGroup")]
        public string UpDateMessageGroup([FromBody] MessageGroup cc)
        {
            return MessageGroupservice.UpDateMessageGroup(cc);
        }
        [HttpGet]
        [Route("GetMessageGroupById/{id}")]
        public MessageGroup GetMessageGroupById(int id)
        {
            return MessageGroupservice.GetMessageGroupById(id); 
        }
    }
}
