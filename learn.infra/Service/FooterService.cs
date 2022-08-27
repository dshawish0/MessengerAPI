using Messenger.core.Data;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class FooterService: IFooterService
    {
        private readonly IFooterService  footerService;

        public FooterService(IFooterService footerService)
        {
            this.footerService = footerService;
        }

        public bool DeleteFooter(int id)
        {
            return footerService.DeleteFooter(id);
        }

        public List<Footer> GetFooter()
        {
            return footerService.GetFooter();
        }

        public Footer GetFooterById(int id)
        {
            return footerService.GetFooterById(id);
        }

        public bool InsertFooter(Footer footer)
        {
            return footerService.InsertFooter(footer);
        }

        public bool UpdateFooter(Footer footer)
        {
            return footerService.UpdateFooter(footer);
        }
    }
}
