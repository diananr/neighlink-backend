using System;
using System.Collections.Generic;
using System.Text;
using Neighlink.Entity;
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

        public int SaveNewUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user.Id;
        }
    }
}
