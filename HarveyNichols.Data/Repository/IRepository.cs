using HarveyNichols.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HarveyNichols.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Remove(int id);
        void Update(T entity);
        bool Any(Expression<Func<T, bool>> predicate = null);
        T GetById(int id);
    }
}
