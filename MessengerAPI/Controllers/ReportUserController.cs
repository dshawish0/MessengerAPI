using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportUserController : Controller
    {
        private readonly IReportUserService reportUserService;
        public ReportUserController(IReportUserService reportUserService)
        {
            this.reportUserService = reportUserService;
        }
        [HttpGet]
        [Route("GetReportUsers")]
        public IActionResult GetReportUsers()
        {
            var result = reportUserService.GetReportUsers();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetReportUsersById/{id}")]
        public IActionResult GetReportUsersById(int id)
        {
            var result = reportUserService.GetReportUsersById(id);
            return Ok(result);
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult InsertReportUser([FromBody] ReportUser report)
        {

            var result = reportUserService.InsertReportUser(report);
            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateReportUser([FromBody] ReportUser report)
        {
            var result = reportUserService.UpdateReportUser(report);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteReportUser/{id}")]
        public IActionResult DeleteReportUser(int id)
        {
            var result = reportUserService.DeleteReportUser(id);
            return Ok(result);
        }
    }
}
