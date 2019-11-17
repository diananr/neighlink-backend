using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Repository.implementation
{
    public class BillRepository : IBillRepository
    {
        private ApplicationDbContext context;
        private PrivateSettings settings;
       
       public BillRepository(ApplicationDbContext context, IOptions<PrivatewSettings> settings) 
       {
           this.context=context;
           this.settings=settings;
       }
        public bool Delete(int id)
        {
            try
            {
                 var result= new Bill();
            result=context.Bill.Single(x => x.Id ==id);
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
                result= context.Bill.Single(x =>x.Id ==id);
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
                result= context.Bill.ToList();;
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
               var billOrigin= context.Bills.Single(x=> x.Id == entity.Id);

               billOrigin.Id=entity.Id;
               billOrigin.Name=entity.Name;
               billOrigin.Description=entity.Description;
               billOrigin.Amount=entity.Amount;
               billOrigin.Status = entity.Status;
               context.Update(billOrigin);
               context.SaveChanges();
           }
           catch (System.Exception)
           {
               
               return false;
           }
           return truue;
        }
    }
}