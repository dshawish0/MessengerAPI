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
        [HttpGet]
        [Route("GetAllServices/{req}")]
        public IActionResult GetAllServices(string req)
        {
            try
            {
                var result = servicesService.GetAllServices(req);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
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

        [HttpPost]
        [Route("AddServices/{req}")]
        public IActionResult AddServices([FromBody] Services services, string req)
        {
            try
            {
                servicesService.AddServices(services, req);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("UpDateServices/{req}")]
        public IActionResult UpDateServices([FromBody] Services services, string req)
        {
            try
            {
                servicesService.UpDateServices(services, req);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteServices/{req}")]
        public IActionResult DeleteServices([FromBody] Services services, string req)
        {
            try
            {
                servicesService.DeleteServices(services.Serviceid, req);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
