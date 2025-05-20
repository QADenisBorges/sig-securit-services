using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class PlanRepository : BaseRepository<Plan>, IPlanRepository
{
    public PlanRepository(DbContext context) : base(context)
    {
    }
}
