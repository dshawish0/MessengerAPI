﻿using Messenger.core.Data;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface ILoginRepository
    {
        public List<Login> GetAllLog();
        public bool InsertLog(UserLogDTO userLog);
        public bool UpdateLog(Login userLog);
    }
}