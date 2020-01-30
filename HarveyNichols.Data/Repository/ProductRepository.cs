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
    public class ProductRepository : IProductRepository
    {
        private readonly HNDbContext _context;
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(HNDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context can not be null.");

            _context = context;
            _dbSet = context.Set<Product>();
        }
        public void Add(Product entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public Product GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public bool Any(Expression<Func<Product, bool>> predicate = null)
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

        public void Update(Product entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
