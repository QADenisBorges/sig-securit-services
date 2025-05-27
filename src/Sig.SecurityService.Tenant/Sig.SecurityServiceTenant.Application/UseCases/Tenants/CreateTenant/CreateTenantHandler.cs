using AutoMapper;
using FluentResults;
using MediatR;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityServiceTenant.Application.UseCases.Tenants.CreateTenant;
using Sig.SecurityServiceTenant.Domain.Entities;
using Sig.SecurityServiceTenant.Domain.Interfaces;

namespace Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;

public class CreateTenantHandler(
    IMapper mapper,
    ITenantRepository tenantRepository,
    IUserRepository userRepository
) : IRequestHandler<CreateTenantCommand, Result<CreateTenantResult>>
{
    private const string DocumentAlreadyInUseCode = "CREATE_TENANT_01";
    private const string UserNotFoundCode = "CREATE_TENANT_02";

    public async Task<Result<CreateTenantResult>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var validationResult = ValidateCommand(request);
        if (validationResult.IsFailed)
            return validationResult.ToResult<CreateTenantResult>();

        var userResult = await CheckUserExistByIdAsync(request.CreateByUserId, cancellationToken);
        if (userResult.IsFailed)
            return userResult.ToResult<CreateTenantResult>();

        var documentResult = await CheckDocumentUniquenessAsync(request.Document, cancellationToken);
        if (documentResult.IsFailed)
            return documentResult.ToResult<CreateTenantResult>();

        var tenant = mapper.Map<Tenant>(request);
        var user = userResult.Value;

        tenant.CreateByUserName = user.Username;
        tenant.CreatedByUser = user;

        var creationResult = await tenantRepository.CreateAsync(tenant, cancellationToken);

        return creationResult.IsSuccess
            ? Result.Ok(mapper.Map<CreateTenantResult>(tenant))
            : Result.Fail(creationResult.Errors);
    }

    private async Task<Result<User>> CheckUserExistByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var userResult = await userRepository.GetByIdAsync(id, cancellationToken);
        if (userResult.IsFailed)
        {
            return Result.Fail("Failed to retrieve user")
                         .WithErrors(userResult.Errors);
        }

        return userResult.Value is not null
            ? Result.Ok(userResult.Value)
            : ValidatorFailure.Fail(UserNotFoundCode)
                .WithError($"User with ID '{id}' does not exist");
    }

    private static Result ValidateCommand(CreateTenantCommand request)
    {
        var validation = new CreateTenantValidator().Validate(request);
        return validation.IsValid
            ? Result.Ok()
            : ValidatorFailure.Fail(validation.Errors);
    }

    private async Task<Result> CheckDocumentUniquenessAsync(string document, CancellationToken cancellationToken)
    {
        var existsResult = await tenantRepository.ExistsByDocumentAsync(document, cancellationToken);
        if (existsResult.IsFailed)
        {
            return Result.Fail("Failed to check document uniqueness")
                         .WithErrors(existsResult.Errors);
        }

        return existsResult.Value
            ? ValidatorFailure.Fail(DocumentAlreadyInUseCode)
                .WithError($"Document '{document}' already in use")
            : Result.Ok();
    }
}
