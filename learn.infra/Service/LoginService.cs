using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Messenger.infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public string Authentication_jwt(Login login)
        {
            var result = loginRepository.Auth(login);

            if (result == null)
                return null;

            var tokenHandeler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Tolen,It can be any string]");
            var tokenDescirptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                     new Claim[]
                     {
                         new Claim(ClaimTypes.Email, result.Email),
                         new Claim(ClaimTypes.Role, result.roleName),
                         new Claim(ClaimTypes.Name, result.userName),
                         new Claim(ClaimTypes.NameIdentifier,result.User_Id.ToString())
                     }
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var generateToken = tokenHandeler.CreateToken(tokenDescirptor);


            return tokenHandeler.WriteToken(generateToken);
        }

        public List<Login> GetAllLog()
        {
            return loginRepository.GetAllLog();
        }

        public bool InsertLog(UserLogDTO userLog)
        {
            return loginRepository.InsertLog(userLog);
        }

        public bool UpdateLog(Login userLog)
        {
            return loginRepository.UpdateLog(userLog);
        }
    }
}
