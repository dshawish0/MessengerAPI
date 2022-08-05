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
        public List<ReportUser> GetReportUsers()
        {
            return reportUserService.GetReportUsers();
        }
        [HttpGet]
        [Route("GetReportUsersById")]
        public List<ReportUser> GetReportUsersById(int id)
        {
            return reportUserService.GetReportUsersById(id);
        }

        [HttpPost]
        [Route("InsertReportUser")]
        public bool InsertReportUser(ReportUser report)
        {
            return reportUserService.InsertReportUser(report);
        }
        [HttpPut]
        [Route("UpdateReportUser")]
        public bool UpdateReportUser(ReportUser report)
        {
            return reportUserService.UpdateReportUser(report);
        }
        [HttpDelete]
        [Route("DeleteReportUser")]
        public bool DeleteReportUser(int id)
        {
            return reportUserService.DeleteReportUser(id);
        }
    }
}
