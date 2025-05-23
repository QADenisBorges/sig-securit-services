using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.ORM.Repositories;

public class PlanRepository(DbContext context) : BaseRepository<Plan>(context), IPlanRepository
{
}
