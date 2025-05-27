using FluentResults;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Domain.Interfaces;

public interface ITenantRepository : IRepository<Tenant>
{
    public Task<Result<bool>> ExistsByDocumentAsync(string document, CancellationToken cancellationToken);
}
