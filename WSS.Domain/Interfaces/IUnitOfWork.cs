using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WSS.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<T> InTransactionAsync<T>(Func<T> action, bool isDispose = true);
        T InTransaction<T>(Func<T> action);
    }
}
