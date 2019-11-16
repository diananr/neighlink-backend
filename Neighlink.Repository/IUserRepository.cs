using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Repository
{
    public interface IUserRepository : ICrudRepository<User>
    {
        User Authenticate(string email, string password);
    }
}
