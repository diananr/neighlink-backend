using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Service.implementation
{
    public class BillService : IBillService
    {
        private IBillRepository buillRepository;

        public BillService(IBillRepository buillRepository)
        {
            this.buillRepository=buillRepository;
        }
        public bool Delete(int id)
        {
            return buillRepository.Delete(id);
        }

        public Bill Get(int id)
        {
            return buillRepository.Get(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return buillRepository.GetAll();
        }

        public bool Save(Bill entity)
        {
            return buillRepository.Save(entity);
        }

        public bool Update(Bill entity)
        {
            return buillRepository.Update(entity);
        }
    }
}