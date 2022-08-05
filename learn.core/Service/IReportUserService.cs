using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IReportUserService
    {
        public bool InsertReportUser(ReportUser report);
        public List<ReportUser> GetReportUsers();
        public bool UpdateReportUser(ReportUser report);
        public bool DeleteReportUser(int id);
        public List<ReportUser> GetReportUsersById(int id);
    }
}
