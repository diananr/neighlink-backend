using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private ApplicationDbContext context;
        public CondominiumRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
               var result = new Condominium();
               result = context.condominiums.Single(x=> x.Id == id);
               context.Remove(result);
               context.SaveChanges();
               return true;                
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        public Condominium Get(int id)
        {
            var result = new Condominium();
            try{
                result = context.condominiums.Single(x=>x.Id ==id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Condominium> GetAll()
        {
            var result = new List<Condominium>();
            try
            {
                result = context.condominiums.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Condominium entity)
        {
            try{
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Condominium entity)
        {
            try{
                
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}