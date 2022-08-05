using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class GroupMemberService: IGroupMemberService
    {
        private readonly IGroupMemberRepoisitory groupMemberRepoisitory;
        public GroupMemberService(IGroupMemberRepoisitory groupMemberRepoisitory)
        {
            this.groupMemberRepoisitory = groupMemberRepoisitory;
        }

        public bool DeleteGroupMember(int id)
        {
            return groupMemberRepoisitory.DeleteGroupMember(id);
        }

        public List<GroupMember> GetGroupMember()
        {
            return groupMemberRepoisitory.GetGroupMember();
        }

        public List<GroupMember> GetGroupMemberById(int id)
        {
            return groupMemberRepoisitory.GetGroupMemberById(id);
        }

        public bool InsertGroupMember(GroupMember groupMember)
        {
            return groupMemberRepoisitory.InsertGroupMember(groupMember);
        }

        public bool UpdateGroupMember(GroupMember groupMember)
        {
            return groupMemberRepoisitory.UpdateGroupMember(groupMember);
        }
    }
}
