using Messenger.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.core.Repoisitory
{
    public interface ITestimonialRepository
    {
        public List<testimonial> GetAllTests();
        public bool InsertTest(testimonial test);
        public bool DeleteTest(int testId);
        public bool UpdateTest(testimonial test);
        public testimonial GetTestById(int testId);
    }
}
