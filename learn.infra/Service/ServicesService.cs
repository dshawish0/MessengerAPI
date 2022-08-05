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

        public void AddServices(Services services, string httpMethod)
        {
            servicesRepository.AddServices(services, httpMethod);
        }

        public void DeleteServices(int id, string httpMethod)
        {
            servicesRepository.DeleteServices(id, httpMethod);
        }

        public IList<Services> GetAllServices(string httpMethod)
        {
            return servicesRepository.GetAllServices(httpMethod);
        }

        public Services GetServiceById(int id)
        {
            return servicesRepository.GetServiceById(id);
        }

        public void UpDateServices(Services services, string httpMethod)
        {
            servicesRepository.UpDateServices(services, httpMethod);
        }
    }
}
