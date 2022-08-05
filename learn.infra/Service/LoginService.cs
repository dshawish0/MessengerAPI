using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
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

        public List<Login> GetAllLog()
        {
            throw new NotImplementedException();
        }

        public bool InsertLog(UserLogDTO userLog)
        {
            return loginRepository.InsertLog(userLog);
        }

        public bool UpdateLog(Login userLog)
        {
            throw new NotImplementedException();
        }
    }
}
