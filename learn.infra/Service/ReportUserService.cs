using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using Messenger.core.Repoisitory;
using Messenger.core.Data;

namespace learn.infra.Service
{
    public class ReportUserService : IReportUserService
    {
        private readonly IReportUserRepoisitory reportUserRepoisitory;
        private readonly ILoginRepository loginRepository;

        public ReportUserService(IReportUserRepoisitory reportUserRepoisitory, ILoginRepository loginRepository)
        {
            this.reportUserRepoisitory = reportUserRepoisitory;
            this.loginRepository = loginRepository;
        }

        public bool acceptingReportUser(int id)
        {
            ReportUser rep = reportUserRepoisitory.GetReportUsersById(id);
            var log = loginRepository.getById(rep.UserReportedId);
            sendEmailCode(log);
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

        public ReportUser GetReportUsersById(int id)
        {
            return reportUserRepoisitory.GetReportUsersById(id);
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

        void sendEmailCode(Login log)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress(log.userName, log.Email);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "verificationCode";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            bb.HtmlBody = "<html>" + "<h1>" + "Our users reporeted you please read chatting rolse again and be carful" + "</h1>" + "</html>";

            //< a href = 'http://www.example.com' ></ a > "
            ///bb.HtmlBody = "<html>" + "<a href = " + "https://localhost:44318/api/user/ConfirmEmail/" + userLog.verificationCode + ">" + "</a>" + "</html>";
            obj.Body = bb.ToMessageBody();

            SmtpClient emailClinet = new SmtpClient();
            emailClinet.Connect("smtp.gmail.com", 465, true);
            emailClinet.Authenticate("teeeeeestemail@gmail.com", "zvvugvfrinavklfj");
            emailClinet.Send(obj);

            emailClinet.Disconnect(true);
            emailClinet.Dispose();

            DateTime sendEmailTreadEnd = DateTime.Now;
            Console.WriteLine("sendEmailTreadEnd: " + sendEmailTreadEnd);
        }

    }
}