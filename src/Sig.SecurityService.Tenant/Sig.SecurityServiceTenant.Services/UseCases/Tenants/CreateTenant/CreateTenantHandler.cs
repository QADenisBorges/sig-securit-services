using FluentResults;
using MediatR;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors.Errors;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;
using Sig.SecurityServiceTenant.Domain.Validators;

namespace Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;

public class CreateTenantHandler(ITenantRepository repository, IPlanRepository planRepository) : IRequestHandler<CreateTenantCommand, Result<Tenant>>
{
    public async Task<Result<Tenant>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = new TenantValidator().Validate(request.Tenant);
            if (!validationResult.IsValid)
                return new ValidatorError(validationResult);

            await EnsurePlanExistsAsync(request.Tenant.Id, cancellationToken);

            return await repository.AddAsync(request.Tenant, cancellationToken);
        }
        catch (Exception ex)
        {
            return new OperationError(ex);
        }
    }

    private async Task<Result> EnsurePlanExistsAsync(Guid planId, CancellationToken cancellationToken)
    {
        var result = await planRepository.ExistsAsync(planId, cancellationToken);

        if (result.IsFailed)
            return new OperationError(result.Errors);

        return result.Value ?
            Result.Ok() :
            CreateTenantError.PlanIdNotExist(planId);
    }
}