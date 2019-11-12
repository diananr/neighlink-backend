using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Entity.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Service.Implementation
{
    public class UserService : IUserService
    {
        private ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<UserInformation> GetAllUserForAdministrator(int userId)
        {
            return new List<UserInformation>() { new UserInformation() { Id = 1 } };
        }

        public int SaveNewDefaultCondoUser(User user, int condominiumId)
        {
            var matchingCondominium = dbContext.Condominiums.Include(y => y.Roles).Where(x => x.Id == condominiumId).FirstOrDefault();

            if (matchingCondominium.Roles == null) 
            {
                matchingCondominium.Roles = new List<Role>();
            }

            var defaultRole = matchingCondominium.Roles.Where(x => x.Type == UserRole.Owner).FirstOrDefault();
            if (defaultRole == null) 
            {
                defaultRole = new Role()
                {
                    Name = "Owner",
                    Description = "Persona que tiene el apartamento",
                    Type = UserRole.Owner
                };

                matchingCondominium.Roles.Add(defaultRole);
                dbContext.SaveChanges();
            }

            return SaveNewUser(user, defaultRole.Id);
        }

        public int SaveNewUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user.Id;
        }

        public int SaveNewUser(User user, int RoleId)
        {
            var matchingRole = dbContext.Roles.Include(y => y.Users).Where(x => x.Id == RoleId).FirstOrDefault();
            if (matchingRole.Users == null) 
            {
                matchingRole.Users = new List<User>();
            }

            matchingRole.Users.Add(user);
            dbContext.SaveChanges();

            return user.Id;
        }
    }
}
