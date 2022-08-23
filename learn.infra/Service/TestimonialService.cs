using Messenger.core.Data;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            this.testimonialRepository = testimonialRepository;
        }
        public bool DeleteTest(int testId)
        {
            return testimonialRepository.DeleteTest(testId);
        }

        public List<testimonial> GetAllTests()
        {
            return testimonialRepository.GetAllTests();
        }

        public testimonial GetTestById(int testId)
        {
            return testimonialRepository.GetTestById(testId);
        }

        public bool InsertTest(testimonial test)
        {
            return testimonialRepository.InsertTest(test);
        }

        public bool UpdateTest(testimonial test)
        {
            return testimonialRepository.UpdateTest(test);
        }
    }
}
