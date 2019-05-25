using WSS.Domain.Interfaces;
using WSS.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WSS.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private WSSDbContext _dbContext;

        public UnitOfWork(WSSDbContext context)
        {
            _dbContext = context;
        }

        public T InTransaction<T>(Func<T> action)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = action();
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    Dispose(true);
                }
            }
        }

        public async Task<T> InTransactionAsync<T>(Func<T> action, bool isDispose = true)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = await Task.Run(action);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                //    Dispose(isDispose);
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                }
            }
        }
    }
}
