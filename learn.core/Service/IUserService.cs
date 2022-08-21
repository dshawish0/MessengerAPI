using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface IUserService
    {
        public List<Userr> GetAllUsers();
        public bool InsertUser(UserLogDTO userLog);
        public bool DeleteUser(int UserId);
        public bool UpdateUser(Userr user);
        public Userr GetUserById(int userId);
        public Userr GetUserByUserName(string userName);
        public string confirmEmail(string code);
    }
}
