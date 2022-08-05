using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.DTO
{
    public class UserLogDTO
    {
        public int User_Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string ProFileImg { get; set; }
        public string Gender { get; set; }

        //LogData
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
