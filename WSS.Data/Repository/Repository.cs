using Microsoft.EntityFrameworkCore;
using WSS.Domain.Interfaces;
using WSS.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WSS.Data.Repository
{
    public class Repository<T> : PagingRepository<T>, IRepository<T> where T : class
    {
        private WSSDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(WSSDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include)
        {
            return await _dbSet.Include(include).Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] include)
        {
            //add includes in dbSet
            IQueryable<T> query = _dbSet;
            foreach (var property in include)
            {
                query = query.Include(property);
            }

            return await query.Where(predicate).ToListAsync();
        }
        
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

    }
}
