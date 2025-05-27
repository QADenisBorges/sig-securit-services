using FluentResults;
using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class TenantRepository(TenantDbContext context) : BaseRepository<Tenant>(context), ITenantRepository
{
    public async Task<Result<bool>> ExistsByDocumentAsync(string document, CancellationToken cancellationToken)
        => await context.Set<Tenant>()
            .AsNoTracking()
            .AnyAsync(t => t.Document.Number == document, cancellationToken);
}
