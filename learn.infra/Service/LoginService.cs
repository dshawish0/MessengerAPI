using MailKit.Net.Smtp;
using Messenger.core;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace Messenger.infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        private readonly IUserRepository UserRepository;

        public LoginService(ILoginRepository loginRepository, IUserRepository UserRepository)
        {
            this.loginRepository = loginRepository;
            this.UserRepository = UserRepository;
        }

        public string Authentication_jwt(Login login)
        {
            var result = loginRepository.Auth(login);

            if (result == null)
                return null;

            var tokenHandeler = new JwtSecurityTokenHandler();
            var restlt = UserRepository.GetUserById(result.User_Id);
            var res = loginRepository.getLogByEmail(result.Email);
            var tokenKey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Tolen,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                     new Claim[]
                     {
                         new Claim(ClaimTypes.Email, result.Email),
                         new Claim(ClaimTypes.Role, result.roleName),
                         new Claim(ClaimTypes.Name, result.userName),
                         new Claim(ClaimTypes.NameIdentifier,result.User_Id.ToString()),
                         new Claim(ClaimTypes.GivenName, NullToString(res.verificationCode)),
                         new Claim(ClaimTypes.Surname, restlt.IsBlocked.ToString())
                     }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var generateToken = tokenHandeler.CreateToken(tokenDescirptor);


            
            restlt.IsActive = 1;
            UserRepository.activationChange(restlt);
            UserLogDTO userLog = new UserLogDTO();
            userLog.UserId= restlt.UserId;
            userLog.userName = result.userName;
            userLog.Email = result.Email;
            userLog.Password = login.Password;
            Global.userLog = userLog;
            return tokenHandeler.WriteToken(generateToken);
        }

        public List<Login> GetAllLog()
        {
            return loginRepository.GetAllLog();
        }

        public bool InsertLog(UserLogDTO userLog)
        {
            Userr user = UserRepository.GetUserByUserName(userLog.userName);
            userLog.UserId = user.UserId;
            Global.userLog = userLog;
            DateTime addUserTreadEnd = DateTime.Now;
            Console.WriteLine("addUserTreadEnd: " + addUserTreadEnd);
            return loginRepository.InsertLog(userLog);
        }

        public bool UpdateLog(Login userLog)
        {
            return loginRepository.UpdateLog(userLog);
        }


        public bool restPassword(Login login)
        {
            
            return UpdateLog(login);


        }

        public Login getLogByEmail(string email)
        {
            var log = loginRepository.getLogByEmail(email);

            if (log == null)
                return null;
            //sendEmailCode(log);
            return log;
        }

        public void sendEmailCode(Login log)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress(log.userName, log.Email);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "Rest Password";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            //bb.HtmlBody = "<html>" + "<h1>" + "http://localhost:4200/log/restPassword/"+log.LoginId + "</h1>" + "</html>";
            bb.HtmlBody = Email();

            //< a href = 'http://www.example.com' ></ a > "
            // bb.HtmlBody = "<html>" + "<a href = " + "https://localhost:44318/api/user/ConfirmEmail/" + userLog.verificationCode + ">" + "</a>" + "</html>";
            obj.Body = bb.ToMessageBody();

            SmtpClient emailClinet = new SmtpClient();
            emailClinet.Connect("smtp.gmail.com", 465, true);
            emailClinet.Authenticate("deia3.123.ds@gmail.com", "lpuesonkyibstcqt");
            emailClinet.Send(obj);

            emailClinet.Disconnect(true);
            emailClinet.Dispose();
        }

        public bool UpdateVerificationCode(UserLogDTO userLog)
        {
            return loginRepository.UpdateVerificationCode(userLog);
        }

        public string ChangeCurrentPassword(UserChangeCurrPass userChangeCurrPass)
        {
            var resalt= this.loginRepository.getById(userChangeCurrPass.userId);
            if (resalt.Password.Equals(userChangeCurrPass.oldPassword))
            {
                loginRepository.ChangeCurrentPassword(userChangeCurrPass);
                return "true";
            }
            return "false";
        }

        public static string NullToString(Object Obj)
        {
            if (Obj == null)
                return "null";
            return Obj.ToString();
        }

        public string Email()
        {
            var pathToFile = "C:\\Users\\LEGION\\source\\repos\\MessengerAPI\\MessengerAPI\\EmailView\\Email\\EEmail.html";


            string HtmlBody = "";
            using (StreamReader streamReader = System.IO.File.OpenText(pathToFile))
            {
                HtmlBody = streamReader.ReadToEnd();
            }
            //< td class="ctaButton" align="center" style="background-color:#1c9dea;padding:15px 35px;">
            string s= "<td class=" +'"'+"ctaButton"+'"'+" align="+'"'+"center"+'"'+" style="+'"'+"background-color:#1c9dea;padding:15px 35px;"+'"'+">";
            s += "<a class=" + '"' + "text" + '"' + "href=http://localhost:4200/log/PasswordReset" + " style=" + '"' + "color:#FFFFFF; font-size:13px; font-weight:900;" + '"' + ">RestPassword Now</a>";
            s += "</td>";
            string massageBody = string.Format(HtmlBody, s, "https://tlr.stripocdn.email/content/guids/CABINET_dd354a98a803b60e2f0411e893c82f56/images/23891556799905703.png");

            return massageBody;
        }
    }
}
