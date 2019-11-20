using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            this.paymentRepository=paymentRepository;
        }
        public bool Delete(int id)
        {
            return paymentRepository.Delete(id);
        }

        public Payment Get(int id)
        {
            return paymentRepository.Get(id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return paymentRepository.GetAll();
        }

        public bool Save(Payment entity)
        {
            return paymentRepository.Save(entity);
        }

        public bool Update(Payment entity)
        {
            return paymentRepository.Update(entity);
        }

        public IEnumerable<Payment> GetPaymentByBill(int billId)
        {
            return paymentRepository.GetPaymentByBill(billId);
        }

        public IEnumerable<Payment> GetPaymentsByUser(int userId)
        {
            return paymentRepository.GetPaymentsByUser(userId);
        }
    }
}