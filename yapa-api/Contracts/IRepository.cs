using System.Collections.Generic;

namespace yapa_api.Contracts
{
    public interface IEntity
    {
        long Id { get; set; }
    }

    public interface IRepository<T> where T : class, IEntity
    {
        T Add(T mainCategory);
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Remove(long id);
        T Update(T mainCategory);
        bool Exists(long id);
    }
}
