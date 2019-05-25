using WSS.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSS.Domain.Interfaces.Auth
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
        Task<Users> FindByUserName(string name);
        Task<Users> getByIdNoTracking(int id);
    }
}
