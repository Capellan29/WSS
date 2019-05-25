using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using WSS.Domain.Interfaces.Auth;
using WSS.Domain.Models.Auth;
using WSS.Data.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WSS.Data.Repository.Auth
{
    public class RoleRepository : Repository<Roles>, IRoleRepository
    {
        private WSSDbContext _context;
        private DbSet<Roles> _dbSet;

        public RoleRepository(WSSDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Roles>();
        }

        public async Task<Roles> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbSet.AsAsyncEnumerable()
                           .SingleOrDefault(p => p.Name.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }
    }
}
