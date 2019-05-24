using WSS.Domain.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WSS.Domain.Interfaces
{
    public interface IRepository<T> : IPagingRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include);
        void Update(T entity);
        void Delete(int id);
    }
}
