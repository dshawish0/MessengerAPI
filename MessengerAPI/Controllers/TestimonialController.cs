using Messenger.core.Data;
using Messenger.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            this.TestimonialService = TestimonialService;
        }
        [HttpGet]
        [Route("GetAllTests")]
        public List<testimonial> GetAllTests()
        {
            return TestimonialService.GetAllTests();
        }
        [HttpPut]
        [Route("AcceptTest")]
        public IActionResult AcceptTest(testimonial test)
        {
            try
            {
                var result = TestimonialService.AcceptTest(test);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("RejectTest")]
        public IActionResult RejectTest(testimonial test)
        {
            try
            {
                var result = TestimonialService.RejectTest(test);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
