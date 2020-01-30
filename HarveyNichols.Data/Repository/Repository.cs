using HarveyNichols.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HNDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(HNDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context can not be null.");

            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public bool Any(Expression<Func<T, bool>> predicate = null)
        {
            return _dbSet.AsNoTracking().Any(predicate);
        }
        public void Remove(int id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            Update(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
