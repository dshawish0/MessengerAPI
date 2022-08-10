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
        public IActionResult GetGroupMember()
        {
            var result = groupMemberService.GetGroupMember();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetGroupMemberById/{id}")]
        public IActionResult GetGroupMemberById(int id)
        {
            var result = groupMemberService.GetGroupMemberById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertGroupMember")]
        public IActionResult InsertGroupMember(GroupMember groupMember)
        {
            var result = groupMemberService.InsertGroupMember(groupMember);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateGroupMember")]
        public IActionResult UpdateGroupMember(GroupMember groupMember)
        {
            var result = groupMemberService.UpdateGroupMember(groupMember);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteGroupMember/{id}")]
        public IActionResult DeleteGroupMember(int id)
        {
            var result = groupMemberService.DeleteGroupMember(id);
            return Ok(result);
        }
    }
}
