using FluentValidation;
using MediatR;
using Sig.SecurityServiceTenant.Domain.Interfaces;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using FluentResults;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

public class DeleteUserHandler(
    IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var deletedResul = await userRepository.DeleteAsync(request.Id, cancellationToken);
        if (deletedResul.IsFailed)
            return ExceptionalFailure.Fail($"User with ID {request.Id} not found");

        return Result.Ok();
    }
}
