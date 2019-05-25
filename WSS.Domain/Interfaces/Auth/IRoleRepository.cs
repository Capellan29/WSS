using WSS.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSS.Domain.Interfaces.Auth
{
    public interface IRoleRepository : IRepository<Roles>
    {
        Task<Roles> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
