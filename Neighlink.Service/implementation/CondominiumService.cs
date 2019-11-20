using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class CondominiumService : ICondominiumService
    {
        private ICondominiumRepository condominiumRepository;
        public CondominiumService(ICondominiumRepository condominiumRepository)
        {
            this.condominiumRepository = condominiumRepository;
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Condominium Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Condominium> GetAll()
        {
            return condominiumRepository.GetAll();
        }

        public bool Save(Condominium entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Condominium entity)
        {
            throw new System.NotImplementedException();
        }
    }
}