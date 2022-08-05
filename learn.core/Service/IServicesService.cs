using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IServicesService
    {
        //public T CrudServices<T>(Services services, string httpMethod);

        public IList<Services> GetAllServices(string httpMethod);
        public void AddServices(Services services, string httpMethod);
        public void DeleteServices(int id, string httpMethod);
        public void UpDateServices(Services services, string httpMethod);
        public Services GetServiceById(int id);
    }
}
