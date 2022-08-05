using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IServicesService
    {
        public T CrudServices<T>(Services services, string httpMethod);
        public Services GetServiceById(int id);
    }
}
