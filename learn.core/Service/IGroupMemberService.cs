using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IGroupMemberService
    {
        public bool InsertGroupMember(GroupMember groupMember);
        public List<GroupMember> GetGroupMember();
        public bool UpdateGroupMember(GroupMember groupMember);
        public bool DeleteGroupMember(int id);
        public List<GroupMember> GetGroupMemberById(int id);
    }
}
