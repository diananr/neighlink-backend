using System.Collections.Generic;
using Neighlink.Entity.Entity;

namespace Neighlink.Repository
{
    public interface IPollRepository:ICrudRepository<Poll>
    {
         IEnumerable<Poll> GetNewsByCondominium(int condominiumId);
    }
}