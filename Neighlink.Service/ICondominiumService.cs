using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface ICondominiumService
    {
        List<Condominium> GetAllCondosForUser(int userId);

        int SaveNewCondominium(Condominium condominium, int planId);
    }
}
