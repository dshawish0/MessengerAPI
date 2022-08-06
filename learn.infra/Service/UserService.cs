using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
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
            return UserRepository.InsertUser(userLog);
        }

        public bool UpdateUser(Userr user)
        {
            return UserRepository.UpdateUser(user);
        }
    }
}
