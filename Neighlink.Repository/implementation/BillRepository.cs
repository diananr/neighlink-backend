using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using System.Linq;

namespace Neighlink.Repository.implementation
{
    public class BillRepository : IBillRepository
    {

        private ApplicationDbContext context;

        public BillRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = new Bill();
                result=context.Bills.Single(x =>x.Id ==id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Bill Get(int id)
        {
            var result= new Bill();
            try
            {
                result=context.Bills.Single(x=>x.Id==id);
        
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Bill> GetAll()
        {
             var result= new List<Bill>();
            try
            {
                result=context.Bills.ToList();
        
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Bill entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Update(Bill entity)
        {
            try
            {
                var billOrigin=context.Bills.Single(x=>x.Id==entity.Id);
                billOrigin.Id=entity.Id;
                billOrigin.Name=entity.Name;
                billOrigin.Amount=entity.Amount;
                billOrigin.Description=entity.Description;
                billOrigin.Status=entity.Status;
                context.Update(billOrigin);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public IEnumerable<Bill> GetBillByPaymentCategory(PaymentCategory paymentCategory_id)
        {
            try
            {
                var bills = context.Bills.Where(x => x.PaymentCategory_id == paymentCategory_id);
                return bills;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


          public IEnumerable<Bill> GetBillByBuilding(Building building_id)
        {
            try
            {
                var bills = context.Bills.Where(x => x.Building_id == building_id);
                return bills;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}