using System.Collections.Generic;
using Neighlink.Entity.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class PollService : IPollService
    {
        private IPollRepository pollRepository;
        public PollService(IPollRepository pollRepository)
        {
            this.pollRepository=pollRepository;
        }
        public bool Delete(int id)
        {
            return pollRepository.Delete(id);
        }

        public Poll Get(int id)
        {
            return pollRepository.Get(id);
        }

        public IEnumerable<Poll> GetAll()
        {
            return pollRepository.GetAll();
        }

        public bool Save(Poll entity)
        {
            return pollRepository.Save(entity);
        }

        public bool Update(Poll entity)
        {
            return pollRepository.Update(entity);
        }

         public IEnumerable<Poll> GetNewsByCondominium(int condominiumId)
        {
            return pollRepository.GetNewsByCondominium(condominiumId);
        }
    }
}