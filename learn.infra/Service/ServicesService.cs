using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository servicesRepository;

        public ServicesService(IServicesRepository servicesRepository)
        {
            this.servicesRepository = servicesRepository;
        }
        public T CrudServices<T>(Services services, string httpMethod)
        {
            return servicesRepository.CrudServices<T>(services, httpMethod);
        }

        public Services GetServiceById(int id)
        {
            return servicesRepository.GetServiceById(id);
        }
    }
}
