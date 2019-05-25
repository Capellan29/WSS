using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using WSS.Domain.Interfaces;
using WSS.Domain.Interfaces.Auth;
using WSS.Domain.Models.Auth;
using WSS.Data.Context;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WSS.Data.Repository.Auth
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        private WSSDbContext _context;
        private DbSet<Users> _dbSet;
        public UserRepository(WSSDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Users>();
        }

        public async Task<Users> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().AsAsyncEnumerable()
                           .SingleOrDefault(p => p.User.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public async Task<Users> FindByUserName(string name)
        {
            return await _dbSet.AsNoTracking().Where(x => x.User == name).FirstOrDefaultAsync();
        }

        public async Task<Users> getByIdNoTracking(int id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.UserId == id).FirstOrDefaultAsync();
        }
    }
}
