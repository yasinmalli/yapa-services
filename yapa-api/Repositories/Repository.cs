using System.Collections.Generic;
using System.Linq;
using yapa_api.Models;

namespace yapa_api.Contracts
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly personalDbContext _context;
        public Repository(personalDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual bool Exists(long id)
        {
            return _context.Set<T>().Any(c => c.Id == id);
        }

        public virtual T GetById(long id)
        {
            return _context.Set<T>().SingleOrDefault(c => c.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T Remove(long id)
        {
            var entity = _context.Set<T>().Single(c => c.Id == id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
