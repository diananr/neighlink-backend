using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Service
{
    public interface IOptionService:ICrudService<Option>
    {
         IEnumerable<Option> GetOptionByPoll(int pollid);
    }
}