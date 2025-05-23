using FluentResults;
using MediatR;
using Sig.SecurityServiceTenant.Application.Features.Tenants.RegisterTernant;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;

public sealed record class CreateTenantCommand(Tenant Tenant) : IRequest<Result<Tenant>>
{
    
}
