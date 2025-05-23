using AutoMapper;
using FluentResults;
using MediatR;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;
using Sig.SecurityServiceTenant.Domain.UseCases.Address;
using Sig.SecurityServiceTenant.Domain.UseCases.Tenants.CreateTenant;

namespace Sig.SecurityServiceTenant.Application.UseCases.Tenants.RegisterTernant;

public class RegisterTenantHandler(
    IMediator mediator, 
    IMapper mapper, 
    ITenantRepository tenantRepository) : IRequestHandler<RegisterTenantCommand, Result<RegisterTenantResult>>
{
    public async Task<Result<RegisterTenantResult>> Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
    {
        var addressResult = await CreateAddressAsync(request, cancellationToken);

        if (addressResult.IsFailed)
            return Result.Fail(addressResult.Errors);

        return await CreateTenantAsync(request, cancellationToken);
    }

    private async Task<Result<CreateAddressResult>> CreateAddressAsync(RegisterTenantCommand request, CancellationToken cancellationToken)
    {
        var addressCommand = mapper.Map<CreateAddressCommand>(request);
        return await mediator.Send(addressCommand);
    }

    private async Task<Result<RegisterTenantResult>> CreateTenantAsync(RegisterTenantCommand request, CancellationToken cancellationToken)
    {
        var tenant = mapper.Map<Tenant>(request);
        var creationResult = await tenantRepository.AddAsync(tenant, cancellationToken);

        if (creationResult.IsFailed)
            return Result.Fail(creationResult.Errors);

        var result = mapper.Map<RegisterTenantResult>(tenant);
        return Result.Ok(result);
    }
}