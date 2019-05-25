using WSS.Domain.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WSS.Domain.Interfaces
{
    public interface IPagingRepository<T> where T : class
    {
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams);
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams, Expression<Func<T, bool>> search);
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams, Expression<Func<T, object>> include);
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams, Expression<Func<T, object>>[] include);
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams, Expression<Func<T, object>> include, Expression<Func<T, bool>> search);
        Task<Paging<T>> GetAllPaging(PagingParams pagingParams, Expression<Func<T, object>>[] include, Expression<Func<T, bool>> search);

    }
}
