using learn.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class FrindService : IFrindService
    {
        private readonly IFrindRepository frindRepository;

        public FrindService(IFrindRepository frindRepository)
        {
            this.frindRepository = frindRepository;
        }
        public void AddFrind(Frinds frind)
        {
            frindRepository.AddFrind(frind);
        }

        public void DeleteFrind(int userId, int reciveId)
        {
            frindRepository.DeleteFrind(userId, reciveId);
        }

        public IList<Frinds> GetAllFrinds(int userId)
        {
            return frindRepository.GetAllFrinds(userId);
        }

        public Frinds GetFrindById(int userId, int reciveId)
        {
            return frindRepository.GetFrindById(userId, reciveId);
        }

        public void UpdateFrind(Frinds frind)
        {
            frindRepository.UpdateFrind(frind);
        }
    }
}
