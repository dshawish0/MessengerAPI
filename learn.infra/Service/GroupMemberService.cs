using learn.core.Data;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class GroupMemberService: IGroupMemberService
    {
        private readonly IGroupMemberService groupMemberService;
        public GroupMemberService(IGroupMemberService _groupMemberService)
        {
            this.groupMemberService = _groupMemberService;
        }

        public bool DeleteGroupMember(int id)
        {
            return groupMemberService.DeleteGroupMember(id);
        }

        public List<GroupMember> GetGroupMember()
        {
            return groupMemberService.GetGroupMember();
        }

        public List<GroupMember> GetGroupMemberById(int id)
        {
            return groupMemberService.GetGroupMemberById(id);
        }

        public bool InsertGroupMember(GroupMember groupMember)
        {
            return groupMemberService.InsertGroupMember(groupMember);
        }

        public bool UpdateGroupMember(GroupMember groupMember)
        {
            return groupMemberService.UpdateGroupMember(groupMember);
        }
    }
}
