using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class BuildingRepository : IBuildingRepository
    {
        private ApplicationDbContext context;
        public BuildingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {

           try
           
            {
                var result = new Building();
                result = context.Buildings.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public Building Get(int id)
        {
            var result = new Building();
            try{
                result = context.Buildings.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Building> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Building entity)
        {
            try{
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Building entity)
        {
            try{
                var buildingOrigin = context.Buildings.Single(x=> x.Id == entity.Id);
                buildingOrigin.Name = entity.Name;
                buildingOrigin.Status = entity.Status;
                buildingOrigin.Description = entity.Description;
                buildingOrigin.NumberOfHomes = entity.NumberOfHomes;
                context.Update(buildingOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Building> GetBuildingsByCondominium(int condominiumId)
        {
            try
            {
                var buildings = context.Buildings.Where(x => x.CondominiumId == condominiumId);
                return buildings;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}