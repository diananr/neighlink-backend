using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Service.Implementation
{
    public class BuildingService : IBuildingService
    {
        private ApplicationDbContext dbContext;

        public BuildingService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Building> GetAllBuildingsAtCondo(int condominiumId)
        {
            var condominium = dbContext.Condominiums.Include(y => y.Buildings).Where(x => x.Id == condominiumId).FirstOrDefault();

            return condominium.Buildings.ToList();
        }

        public List<Building> GetAllBuildingsForUser(int userId)
        {
            var roles = dbContext.Roles.Where(x => x.Users.Select(y => y.Id).Contains(userId));
            List<Condominium> result = new List<Condominium>();
            foreach (var role in roles)
            {
                var condominiumsForRole = dbContext.Condominiums.Include(y => y.Buildings)
                                                                .Where(x => x.Roles.Select(y => y.Id).Contains(role.Id));
                result.AddRange(condominiumsForRole);
            }

            return result.SelectMany(x => x.Buildings).ToList();
        }

        public int SaveBuildingToCondominium(Building building, int condominiumId)
        {
            var condominium = dbContext.Condominiums.Include(y => y.Buildings).Where(x => x.Id == condominiumId).FirstOrDefault();

            if (condominium.Buildings == null) 
            {
                condominium.Buildings = new List<Building>();
            }

            condominium.Buildings.Add(building);
            dbContext.SaveChanges();

            return building.Id;
        }
    }
}
