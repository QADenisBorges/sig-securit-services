using FluentResults;
using MediatR;
using Sig.SecurityService.Tenant.Common.Results.CustomErrors;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;
using Sig.SecurityServiceTenant.Domain.Validations;
using Sig.SecurityServiceTenant.Domain.Validators;

namespace Sig.SecurityServiceTenant.Domain.UseCases.Tenants.CreateTenant;

public class CreateTenantHandler(IMediator mediator, ITenantRepository repository) : IRequestHandler<CreateTenantCommand, Result<Tenant>>
{
    public async Task<Result<Tenant>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenantValid = new TenantValidator().Validate(request.Tenant);
        if (!tenantValid.IsValid)
            return new ValidationError(tenantValid);

        var resultCreatedTenant = await repository.AddAsync(request.Tenant, cancellationToken);

        return resultCreatedTenant;
    }
}