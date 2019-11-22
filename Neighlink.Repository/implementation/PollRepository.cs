using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class PollRepository : IPollRepository
    {
        private ApplicationDbContext context;
        public PollRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = new Poll();
                result = context.Polls.Single(x=> x.Id == id ); 
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        public Poll Get(int id)
        {
            var result = new Poll();
            try {
                result = context.Polls.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Poll> GetAll()
        {
            var result = new List<Poll>();
            try{
                result = context.Polls.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Poll entity)
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

        public bool Update(Poll entity)
        {
            try{
                var pollOrigin = context.Polls.Single(x => x.Id == entity.Id);
                pollOrigin.Id = entity.Id;
                pollOrigin.Status = entity.Status;
                pollOrigin.Title = entity.Title;
                pollOrigin.Description = entity.Description;
                pollOrigin.StarDate = entity.StarDate;
                pollOrigin.EndDate = entity.EndDate;
                context.Update(pollOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return false;
        }

        public IEnumerable<Poll> GetNewsByCondominium(int condominiumId)
        {
            try
            {
                var polls = context.Polls.Where(x => x.CondominiumId == condominiumId);
                return polls;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}