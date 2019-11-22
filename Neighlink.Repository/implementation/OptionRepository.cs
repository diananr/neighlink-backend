using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class OptionRepository : IOptionRepository
    {
        private ApplicationDbContext context;
        public OptionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
           try
            {
                var result = new Option();
                result = context.Options.Single(x=> x.Id == id ); 
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        public Option Get(int id)
        {
            var result = new Option();
            try {
                result = context.Options.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Option> GetAll()
        {
           var result = new List<Option>();
            try{
                result = context.Options.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Option entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Option entity)
        {
            try{
                var optionOrigin = context.Options.Single(x => x.Id == entity.Id);
                optionOrigin.Id = entity.Id;
                optionOrigin.Status = entity.Status;
                optionOrigin.Name = entity.Name;
                optionOrigin.Description = entity.Description;
                context.Update(optionOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return false;
        }

        public IEnumerable<Option> GetOptionByPoll(int pollid)
        {
            try
            {
                var options = context.Options.Where(x => x.PollId == pollid);
                return options;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}