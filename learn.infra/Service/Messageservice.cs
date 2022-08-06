using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class Messageservice : IMessageservice
    {
        private readonly IMessageRepoisitory MessageRepoisitory;
        public Messageservice(IMessageRepoisitory MessageRepoisitory)
        {
            this.MessageRepoisitory = MessageRepoisitory;
        }
        public string CreateMessage(Message ins)
        {
           return MessageRepoisitory.CreateMessage(ins);    
        }

        public string DeleteMessage(int id)
        {
            return MessageRepoisitory.DeleteMessage(id);
        }

        public List<Message> GetAllMessage()
        {
            return MessageRepoisitory.GetAllMessage();
        }

        public Message GetMessageById(int id)
        {
            return MessageRepoisitory.GetMessageById(id);
        }

        public string UpDateMessage(Message upd)
        {
            return MessageRepoisitory.UpDateMessage(upd);
        }
    }
}
