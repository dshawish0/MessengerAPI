using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace learn.core.Repoisitory
{
    public interface IPaymentRepository
    {
        public IList<Payments> GetAllPayments();
        public void AddPayments(Payments payment);
        public void DeletePayments(int id);
        public void UpDatePayments(Payments payment);
        public Payments GetPaymentsById(int id);

        public Task<IList<Payments>> GetPaymentsByUserId(int userId);
    }
}
