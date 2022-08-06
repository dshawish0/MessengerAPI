using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IMessageRepoisitory
    {
        public List<Message> GetAllMessage();
        public Message GetMessageById(int id);
        public string CreateMessage(Message ins);
        public string UpDateMessage(Message upd);
        public string DeleteMessage(int id);
    }
}
