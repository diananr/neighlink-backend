using System.Collections.Generic;
using Neighlink.Entity;
using System.Linq;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class NewRepository : INewRepository
    {
        private ApplicationDbContext context;
        public NewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = new News();
                result = context.news.Single(x=> x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
                throw;
            }
        }

        public News Get(int id)
        {
            var result = new News();
            try{
                result = context.news.Single(x=>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<News> GetAll()
        {
             var result = new List<News>();
            try
            {
                result = context.news.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(News entity)
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

        public bool Update(News entity)
        {
            try{
                var newOrigin = context.news.Single(
                    x=> x.Id == entity.Id);

                newOrigin.Id = entity.Id;
                newOrigin.Title = entity.Title;
                newOrigin.Description = entity.Description;
                context.Update(newOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}