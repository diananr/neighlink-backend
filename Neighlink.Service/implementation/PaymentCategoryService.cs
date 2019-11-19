using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class PaymentCategoryService : IPaymentCategoryService
    {
        private IPaymentCategoryRepository paymentRepository;
        public PaymentCategoryService(IPaymentCategoryRepository paymentRepository)
        {
            this.paymentRepository=paymentRepository;
        }
        public bool Delete(int id)
        {
            return paymentRepository.Delete(id);
        }

        public PaymentCategory Get(int id)
        {
            return paymentRepository.Get(id);
        }

        public IEnumerable<PaymentCategory> GetAll()
        {
            return paymentRepository.GetAll();
        }

        public bool Save(PaymentCategory entity)
        {
            return paymentRepository.Save(entity);
        }

        public bool Update(PaymentCategory entity)
        {
            return paymentRepository.Update(entity);
        }

        public IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId)
        {
            return paymentRepository.GetBuildingsByCondominium(condominiumId);
        }
    }
}