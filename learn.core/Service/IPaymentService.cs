using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Service
{
    public interface IPaymentService
    {
        public IList<Payments> GetAllPayments();
        public void AddPayments(Payments payment);
        public void DeletePayments(int id);
        public void UpDatePayments(Payments payment);
        public Payments GetPaymentsById(int id);
    }
}
