using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public  interface IMessageGroupservice
    {
        public List<MessageGroup> GetAllMessageGroup();
        public MessageGroup GetMessageGroupById(int id);
        public string CreateMessageGroup(MessageGroup ins);
        public string UpDateMessageGroup(MessageGroup upd);
        public string DeleteMessageGroup(int id);
    }
}
