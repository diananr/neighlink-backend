using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class OptionService : IOptionService
    {
        private IOptionRepository optionRepository;
        public OptionService(IOptionRepository optionRepository)
        {
            this.optionRepository=optionRepository;
        }
        public bool Delete(int id)
        {
            return optionRepository.Delete(id);
        }

        public Option Get(int id)
        {
            return optionRepository.Get(id);
        }

        public IEnumerable<Option> GetAll()
        {
            return optionRepository.GetAll();
        }

        public IEnumerable<Option> GetOptionByPoll(int pollid)
        {
            return optionRepository.GetOptionByPoll(pollid);
        }

        public bool Save(Option entity)
        {
            return optionRepository.Save(entity);
        }

        public bool Update(Option entity)
        {
           return optionRepository.Update(entity);
        }
    }
}