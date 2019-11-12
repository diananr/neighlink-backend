using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface IRoleService
    {
        int SaveNewRole(Role role, int condoId);
    }
}
