using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface IDtoRepository
    {
        public GetAllNumberOfFriends getAllNumberOfFriends(int userId);
    }
}
