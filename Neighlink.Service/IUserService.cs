using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface IUserService : ICrudService<User>
    {
        User Authenticate(string email, string password);
    }
}
