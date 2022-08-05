using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Service
{
    public interface IFrindService
    {
        public IList<Frinds> GetAllFrinds(int userId);
        public void AddFrind(Frinds frind);
        public void UpdateFrind(Frinds frind);
        public void DeleteFrind(int userId, int reciveId);
        public Frinds GetFrindById(int userId, int reciveId);
    }
}
