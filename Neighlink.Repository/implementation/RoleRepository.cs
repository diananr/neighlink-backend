using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class RoleRepository : IRoleRepository
    {

        private ApplicationDbContext context;
        public RoleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = new Role();
                result = context.roles.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public Role Get(int id)
        {
            var result = new Role();
            try{
                result = context.roles.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Role> GetAll()
        {
             var result = new List<Role>();
            try
            {
                result = context.roles.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Role entity)
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

        public bool Update(Role entity)
        {
            try{
                var roleOrigin = context.roles.Single(
                    x=> x.Id == entity.Id
                );

                roleOrigin.Id = entity.Id;
                roleOrigin.Name = entity.Name;
                roleOrigin.Status = entity.Status;
                roleOrigin.Description = entity.Description;
                context.Update(roleOrigin);
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