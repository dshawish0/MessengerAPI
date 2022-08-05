
using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface IServicesRepository
    {
        public T CrudServices<T>(Services services, string httpMethod);
        public Services GetServiceById(int id);
    }
}
