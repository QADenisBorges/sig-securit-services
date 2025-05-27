using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
