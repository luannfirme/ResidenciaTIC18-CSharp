using Microsoft.EntityFrameworkCore;
using TechAdv.Domain.Interfaces;
using TechAdv.Persistence.Context;

namespace TechAdv.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TechAdvContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(TechAdvContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual async Task<T> GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }
    }
}
