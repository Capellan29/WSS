using Microsoft.EntityFrameworkCore;
using WSS.Domain.Core.Paging;
using WSS.Domain.Interfaces;
using WSS.Data.Context;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace WSS.Data.Repository
{
    public class PagingRepository<T> : IPagingRepository<T> where T : class
    {
        private WSSDbContext _context;
        private DbSet<T> _dbSet;

        public PagingRepository(WSSDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams)
        {
            int totalItems = _dbSet.Count();

            var param = Expression.Parameter(typeof(T), "item");
            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, pagingParams.sortKey),
                typeof(object)), param);

            var items = (pagingParams.sortDirection == "asc")
                ? await _dbSet.OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await _dbSet.OrderByDescending<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            return new Paging<T>(items, totalItems, pagingParams);
        }

        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams,
            Expression<Func<T, bool>> search)
        {

            var param = Expression.Parameter(typeof(T), "item");
            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, pagingParams.sortKey),
                typeof(object)), param);

            var items = (pagingParams.sortDirection == "asc")
                ? await _dbSet.Where(search)
                    .OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await _dbSet.Where(search)
                    .OrderByDescending<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            int totalItems = _dbSet.Where(search).Count();
            return new Paging<T>(items, totalItems, pagingParams);
        }

        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams,
            Expression<Func<T, object>> include)
        {
            int totalItems = _dbSet.Count();
            var param = Expression.Parameter(typeof(T), "item");

            Expression current = param;
            MemberExpression selector = null;

            foreach (var part in pagingParams.sortKey.Split('.'))
            {
                selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(current, typeof(object)), param);

            var items = (pagingParams.sortDirection == "asc")

                ? await _dbSet.Include(include)
                    .OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await _dbSet.OrderByDescending<T, object>(sortExpression)
                    .Include(include)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            return new Paging<T>(items, totalItems, pagingParams);
        }

        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams,
            Expression<Func<T, object>> include,
             Expression<Func<T, bool>> search)
        {
            var param = Expression.Parameter(typeof(T), "item");

            Expression current = param;
            MemberExpression selector = null;

            foreach (var part in pagingParams.sortKey.Split('.'))
            {
                selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(current, typeof(object)), param);

            var items = (pagingParams.sortDirection == "asc")

                ? await _dbSet.Include(include)
                     .Where(search)
                    .OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await _dbSet.OrderByDescending<T, object>(sortExpression)
                    .Where(search)
                    .Include(include)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            int totalItems = _dbSet.Where(search).Count();
            return new Paging<T>(items, totalItems, pagingParams);
        }

        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams,
            Expression<Func<T, object>>[] include)
        {
            int totalItems = _dbSet.Count();
            var param = Expression.Parameter(typeof(T), "item");

            //metodo short para include
            Expression current = param;
            MemberExpression selector = null;

            foreach (var part in pagingParams.sortKey.Split('.'))
            {
                selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(current, typeof(object)), param);

            //add includes in dbSet
            IQueryable<T> query = _dbSet;
            foreach (var property in include)
            {
                query = query.Include(property);
            }

            var items = (pagingParams.sortDirection == "asc")

                ? await query.OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await query.OrderByDescending<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            return new Paging<T>(items, totalItems, pagingParams);
        }

        public async Task<Paging<T>> GetAllPaging(PagingParams pagingParams,
            Expression<Func<T, object>>[] include,
             Expression<Func<T, bool>> search)
        {
            var param = Expression.Parameter(typeof(T), "item");

            //metodo short para include
            Expression current = param;
            MemberExpression selector = null;

            foreach (var part in pagingParams.sortKey.Split('.'))
            {
                selector = Expression.PropertyOrField(current, part);
                current = selector;
            }

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(current, typeof(object)), param);


            //add includes in dbSet
            IQueryable<T> query = _dbSet;
            foreach (var property in include)
            {
                query = query.Include(property);
            }

            var items = (pagingParams.sortDirection == "asc")

                ? await query.Where(search)
                    .OrderBy<T, object>(sortExpression)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync()

                : await query.OrderByDescending<T, object>(sortExpression)
                    .Where(search)
                    .Skip(pagingParams.PageSize * (pagingParams.PageNumber - 1))
                    .Take(pagingParams.PageSize)
                    .ToListAsync();

            int totalItems = _dbSet.Where(search).Count();
            return new Paging<T>(items, totalItems, pagingParams);
        }

    }
}
