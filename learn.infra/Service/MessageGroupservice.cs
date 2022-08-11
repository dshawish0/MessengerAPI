﻿using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class MessageGroupservice : IMessageGroupservice
    {
        private readonly IMessageGroupRepoisitory MessageGroupRepoisitory;
        public MessageGroupservice(IMessageGroupRepoisitory MessageGroupRepoisitory)
        {
            this.MessageGroupRepoisitory = MessageGroupRepoisitory;
        }
        public string CreateMessageGroup(MessageGroup ins)
        {
           return MessageGroupRepoisitory.CreateMessageGroup(ins);
        }

        public string DeleteMessageGroup(int id)
        {
            return MessageGroupRepoisitory.DeleteMessageGroup(id);  
        }

        public List<MessageGroup> GetAllMessageGroup()
        {
            return MessageGroupRepoisitory.GetAllMessageGroup();
        }

        public MessageGroup GetMessageGroupById(int id)
        {
            return MessageGroupRepoisitory.GetMessageGroupById(id);
        }

        public string UpDateMessageGroup(MessageGroup upd)
        {
            return MessageGroupRepoisitory.UpDateMessageGroup(upd);
        }
    }
}