using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface IUserService
    {
        List<UserInformation> GetAllUserForAdministrator(int userId);

        int SaveNewUser(User user);
    }
}
