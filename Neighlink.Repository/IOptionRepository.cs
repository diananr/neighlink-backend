using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Repository
{
    public interface IOptionRepository:ICrudRepository<Option>
    {
        IEnumerable<Option> GetOptionByPoll(int pollid);
    }
}