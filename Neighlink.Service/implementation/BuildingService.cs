using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class BuildingService : IBuildingService
    {
        private IBuildingRepository buildingRepository;
        public BuildingService(IBuildingRepository buildingRepository)
        {
            this.buildingRepository=buildingRepository;
        }
        public bool Delete(int id)
        {
            return buildingRepository.Delete(id);
        }

        public Building Get(int id)
        {
            return buildingRepository.Get(id);
        }

        public IEnumerable<Building> GetAll()
        {
            return buildingRepository.GetAll();
        }

        public bool Save(Building entity)
        {
            return buildingRepository.Save(entity);
        }

        public bool Update(Building entity)
        {
            return buildingRepository.Update(entity);
        }

        public IEnumerable<Building> GetBuildingsByCondominium(int condominiumId)
        {
            return buildingRepository.GetBuildingsByCondominium(condominiumId);
        }
    }
}