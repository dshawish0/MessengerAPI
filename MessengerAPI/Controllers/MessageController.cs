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
        public List<Message> GetAllMessage()
        {
            return Messageservice.GetAllMessage();
        }
        [HttpDelete]
        [Route("DeleteMessage/{id}")]
        public string DeleteMessage(int id)
        {
            return Messageservice.DeleteMessage(id);

        }
        [HttpPost]
        [Route("CreateMessage")]
        public string CreateMessage([FromBody] Message ins)
        {
            return Messageservice.CreateMessage(ins);
        }

        [HttpPut]
        [Route("UpDateMessage")]
        public string UpDateMessage([FromBody] Message cc)
        {
            return Messageservice.UpDateMessage(cc);    
        }
        [HttpGet]
        [Route("GetMessageById/{id}")]
        public Message GetMessageById(int id)
        {
            return Messageservice.GetMessageById(id);
        }
    }
}
