using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberService groupMemberService;
        public GroupMemberController(IGroupMemberService groupMemberService)
        {
            this.groupMemberService = groupMemberService;
        }
        [HttpGet]
        [Route("GetGroupMember")]
        public List<GroupMember> GetGroupMember()
        {
            return groupMemberService.GetGroupMember();
        }
        [HttpGet]
        [Route("GetReportUsersById/{id}")]
        public List<GroupMember> GetReportUsersById(int id)
        {
            return groupMemberService.GetGroupMemberById(id);
        }

        [HttpPost]
        [Route("InsertGroupMember")]
        public bool InsertGroupMember(GroupMember groupMember)
        {
            return groupMemberService.InsertGroupMember(groupMember);
        }
        [HttpPut]
        [Route("UpdateGroupMember")]
        public bool UpdateGroupMember(GroupMember groupMember)
        {
            return groupMemberService.UpdateGroupMember(groupMember);
        }
        [HttpDelete]
        [Route("DeleteGroupMember")]
        public bool DeleteGroupMember(int id)
        {
            return groupMemberService.DeleteGroupMember(id);
        }
    }
}
