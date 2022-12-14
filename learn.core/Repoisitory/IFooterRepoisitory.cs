using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface IFooterRepoisitory
    {
        public bool InsertFooter(Footer footer);
        public List<Footer> GetFooter();
        public bool UpdateFooter(Footer footer);
        public bool DeleteFooter(int id);
        public Footer GetFooterById(int id);
    }
}
