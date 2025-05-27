using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class UserRepository(TenantDbContext context) : BaseRepository<User>(context), IRepository<User>, IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    
}
