using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface ICrudService<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}