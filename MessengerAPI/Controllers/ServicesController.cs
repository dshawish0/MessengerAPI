using learn.core.Data;
using learn.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }
        [Route("CrudService/{req}")]
        public IActionResult CrudService([FromBody] Services services, string req)
        {

            switch (req)
            {
                case "G":
                    {
                        var result = servicesService.CrudServices<List<Services>>(services, req);
                        return Ok(result);
                    }
                default:
                    {
                        var result = servicesService.CrudServices<bool>(services, req);
                        return Ok(result);
                    }

            }

        }
        [HttpGet]
        [Route("GetServiseById/{id}")]
        public IActionResult GetServiseById(int id)
        {
            try
            {
                var result = servicesService.GetServiceById(id);
                return Ok(result);
            }
            catch (Exception e) 
            {
                return NotFound(e.Message);
            }
        }
    }
}
