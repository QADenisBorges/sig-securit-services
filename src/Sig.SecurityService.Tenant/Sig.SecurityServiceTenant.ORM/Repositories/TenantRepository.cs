using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class TenantRepository(DbContext context) : BaseRepository<Tenant>(context), ITenantRepository
{
}
