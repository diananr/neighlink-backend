using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private ApplicationDbContext dbContext;

        public RoleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int SaveNewRole(Role role, int condoId)
        {
            var matchingCondo = dbContext.Condominiums.Include(y => y.Roles).Where(x => x.Id == condoId).FirstOrDefault();

            if (matchingCondo != null)
            {
                if (matchingCondo.Roles == null)
                {
                    matchingCondo.Roles = new List<Role>();
                }

                matchingCondo.Roles.Add(role);
                dbContext.SaveChanges();
            }

            return role.Id;
        }
    }
}
