using MailKit.Net.Smtp;
using Messenger.core;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly ILoginService LoginService;
        private bool falg = true;

        public UserService(IUserRepository UserRepository, ILoginService LoginService)
        {
            this.UserRepository = UserRepository;
            this.LoginService = LoginService;
        }

        public bool DeleteUser(int UserId)
        {
            return UserRepository.DeleteUser(UserId);
        }

        public List<Userr> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public Userr GetUserById(int userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public Userr GetUserByUserName(string userName)
        {
            return UserRepository.GetUserByUserName(userName);
        }

        public bool InsertUser(UserLogDTO userLog)
        {
            Thread thr = new Thread(() => addUserLogData(userLog));
            thr.Start();
            return UserRepository.InsertUser(userLog);
        }

        public bool UpdateUser(Userr user)
        {
            return UserRepository.UpdateUser(user);
        }





        public void addUserLogData(UserLogDTO userLog)
        {
            Random r = new Random();
            int rInt = r.Next(1000, 100000);
            userLog.verificationCode = rInt.ToString();
            Thread sendEmail = new Thread(() => sendEmailCode(userLog));
            sendEmail.Start();


            Thread addUser = new Thread(() => LoginService.InsertLog(userLog));
            addUser.Start();

            Thread removeCodee = new Thread(removeCode);
            removeCodee.Start();


        }


         void sendEmailCode(UserLogDTO userLog)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress(userLog.userName, userLog.Email);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "verificationCode";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            //bb.HtmlBody = "<html>" + "<h1>" + userLog.verificationCode + "</h1>" + "</html>";

            //< a href = 'http://www.example.com' ></ a > "
            bb.HtmlBody = "<html>" + "<a href = " + "https://localhost:44318/api/user/ConfirmEmail/" + userLog.verificationCode + ">" + "</a>" + "</html>";
            obj.Body = bb.ToMessageBody();

            SmtpClient emailClinet = new SmtpClient();
            emailClinet.Connect("smtp.gmail.com", 465, true);
            emailClinet.Authenticate("teeeeeestemail@gmail.com", "zvvugvfrinavklfj");
            emailClinet.Send(obj);

            emailClinet.Disconnect(true);
            emailClinet.Dispose();
        }

        void removeCode()
        {
            Thread.Sleep(200000);
            //Task.Delay(20000);
            if (falg)
            {
                Login log = new Login();
                log.verificationCode = null;
                log.User_Id = Global.userLog.UserId;
                log.Email = Global.userLog.Email;
                log.Password = Global.userLog.Password;
                log.userName = Global.userLog.userName;

                LoginService.UpdateLog(log);
            }

        }

        public string confirmEmail(string code)
        {
            if (code.Equals(Global.userLog.verificationCode))
            {

                Login log = new Login();
                log.verificationCode = "1";
                log.User_Id = Global.userLog.UserId;
                log.Email = Global.userLog.Email;
                log.Password = Global.userLog.Password;
                log.userName = Global.userLog.userName;

                falg = false;

                LoginService.UpdateLog(log);

                return "email confirmed";
            }
            return "false";
        }

    }
}
