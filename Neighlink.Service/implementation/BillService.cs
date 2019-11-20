using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class BillService : IBillService
    {
        private IBillRepository billRepository;

         public BillService(IBillRepository billRepository)
        {
            this.billRepository=billRepository;
        }
        public bool Delete(int id)
        {
            return billRepository.Delete(id);
        }

        public Bill Get(int id)
        {
            return billRepository.Get(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return billRepository.GetAll();
        }

        public bool Save(Bill entity)
        {
            return billRepository.Save(entity);
        }

        public bool Update(Bill entity)
        {
            return billRepository.Update(entity);
        }

         public IEnumerable<Bill> GetBillByPaymentCategory(PaymentCategory paymentCategory_id)
        {
            return billRepository.GetBillByPaymentCategory(paymentCategory_id);
        }

         public IEnumerable<Bill> GetBillByBuilding(Building building_id)
        {
            return billRepository.GetBillByBuilding(building_id);
        }
    }
}