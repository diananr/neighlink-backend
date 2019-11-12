using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Service.Implementation
{
    public class CondominiumService : ICondominiumService
    {
        private ApplicationDbContext dbContext;

        public CondominiumService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Condominium> GetAllCondosForUser(int userId)
        {
            var roles = dbContext.Roles.Where(x => x.Users.Select(y => y.Id).Contains(userId));
            List<Condominium> result = new List<Condominium>();
            foreach (var role in roles) 
            {
                var condominiumsForRole = dbContext.Condominiums.Where(x => x.Roles.Select(y => y.Id).Contains(role.Id));
                result.AddRange(condominiumsForRole);
            }

            return result;
        }

        public int SaveNewCondominium(Condominium condominium)
        {
            dbContext.Condominiums.Add(condominium);
            dbContext.SaveChanges();

            return condominium.Id;
        }
    }
}
