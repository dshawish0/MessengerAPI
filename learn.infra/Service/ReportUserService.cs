using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class ReportUserService : IReportUserService
    {
        private readonly IReportUserRepoisitory reportUserRepoisitory;

        public ReportUserService(IReportUserRepoisitory reportUserRepoisitory)
        {
            this.reportUserRepoisitory = reportUserRepoisitory;
        }

        public bool acceptingReportUser(int id)
        {
            return reportUserRepoisitory.acceptingReportUser(id);
        }

        public bool DeleteReportUser(int id)
        {
            return reportUserRepoisitory.DeleteReportUser(id);
        }

        public List<ReportUser> GetReportUsers()
        {
            return reportUserRepoisitory.GetReportUsers();
        }

        public List<GetAllReportByUserName> GetReportUsersByName(string name)
        {
            return reportUserRepoisitory.GetReportUsersByName(name);
        }

        public bool InsertReportUser(ReportUser report)
        {
            return reportUserRepoisitory.InsertReportUser(report);
        }

        public bool rejectreport(int id)
        {
            return reportUserRepoisitory.rejectreport(id);
        }

        public bool UpdateReportUser(ReportUser report)
        {
            return reportUserRepoisitory.UpdateReportUser(report);
        }
        public List<GetAllReportByUserName> GetAllByusername()
        {
            return reportUserRepoisitory.GetAllByusername();
        }
    }
}