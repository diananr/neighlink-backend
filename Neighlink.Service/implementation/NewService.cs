using System;
using System.Collections.Generic;
using System.Text;
using Neighlink.Entity;
using Neighlink.Repository;

namespace Neighlink.Service.implementation
{
    public class NewService : INewService
    {
        private INewRepository newRepository;
        public NewService(INewRepository newRepository)
        {
            this.newRepository=newRepository;
        }

        public NewService()
        {
        }

        public bool Delete(int id)
        {
            return newRepository.Delete(id);
        }

        public News Get(int id)
        {
            return newRepository.Get(id);
        }

        public IEnumerable<News> GetAll()
        {
            return newRepository.GetAll();
        }

        public bool Save(News entity)
        {
            return newRepository.Save(entity);
        }

        public bool Update(News entity)
        {
            return newRepository.Update(entity);
        }
        public IEnumerable<News> GetNewsByCondominium(int condominiumId)
        {
            return newRepository.GetNewsByCondominium(condominiumId);
        }
    }
}