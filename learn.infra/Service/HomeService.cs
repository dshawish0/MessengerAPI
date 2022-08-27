using Messenger.core.Data;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeService homeService;
        public HomeService(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public bool DeleteHome(int id)
        {
            return homeService.DeleteHome(id);
        }

        public List<Home> GetHome()
        {
            return homeService.GetHome();
        }

        public Home GetHomeById(int id)
        {
            return homeService.GetHomeById(id);
        }

        public bool InsertHome(Home home)
        {
            return homeService.InsertHome(home);
        }

        public bool UpdateHome(Home home)
        {
            return homeService.UpdateHome(home);
        }
    }
}
