using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechmedCC.Domain.Interfaces;
using TechmedCC.Infra.Context;

namespace TechmedCC.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TechmedContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TechmedContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task Include(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
    }
}
