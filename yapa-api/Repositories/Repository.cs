using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using yapa_api.Models;

namespace yapa_api.Contracts
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly personalDbContext _context;
        private readonly DbSet<T> Entity;
        public Repository(personalDbContext context)
        {
            _context = context;
            Entity = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            Entity.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual bool Exists(long id)
        {
            return Entity.Any(c => c.Id == id);
        }

        public virtual T GetById(long id)
        {
            return Entity.SingleOrDefault(c => c.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Entity;
        }

        public virtual T Remove(long id)
        {
            var entity = _context.Set<T>().Single(c => c.Id == id);
            Entity.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            Entity.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
