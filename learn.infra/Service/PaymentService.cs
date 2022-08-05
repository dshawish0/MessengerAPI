using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }
        public void AddPayments(Payments payment)
        {
            paymentRepository.AddPayments(payment);
        }

        public void DeletePayments(int id)
        {
            paymentRepository.DeletePayments(id);
        }

        public IList<Payments> GetAllPayments()
        {
            return paymentRepository.GetAllPayments();
        }

        public Payments GetPaymentsById(int id)
        {
            return paymentRepository.GetPaymentsById(id);
        }

        public void UpDatePayments(Payments payment)
        {
            paymentRepository.UpDatePayments(payment);
        }
    }
}
