using Neighlink.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service
{
    public interface IBuildingService
    {
        List<Building> GetAllBuildingsForUser(int userId);

        List<Building> GetAllBuildingsAtCondo(int condominiumId);

        int SaveBuildingToCondominium(Building building, int condominiumId);
    }
}
