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
            this.condominiumRepository=condominiumRepository;
        }
        public bool Delete(int id)
        {
            return condominiumRepository.Delete(id);
        }
        public Condominium Get(int id)
        {
            return condominiumRepository.Get(id);
        }

        public IEnumerable<Condominium> GetAll()
        {
            return condominiumRepository.GetAll();
        }

        public bool Save(Condominium entity)
        {
            return condominiumRepository.Save(entity);
        }

        public bool Update(Condominium entity)
        {
            return condominiumRepository.Update(entity);
        }
    }
}