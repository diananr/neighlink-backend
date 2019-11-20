using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private ApplicationDbContext context;

        public CondominiumRepository(ApplicationDbContext context)
        {
            this.context = context;
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
            try
            {
                var result = context.Condominiums.ToList();
                return result;
            }catch(System.Exception)
            {
                return null;
            }
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