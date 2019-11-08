using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface ICrudRepository<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}