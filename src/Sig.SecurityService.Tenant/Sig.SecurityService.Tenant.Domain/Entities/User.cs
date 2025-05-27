using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentResults;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityServiceTenant.Domain.Validators;

namespace Sig.SecurityServiceTenant.Domain.Entities;

public class User : BaseEntity, IUser
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    string IUser.Id => Id.ToString();
    string IUser.Username => Username;
    string IUser.Role => Role.ToString();

    public IEnumerable<Tenant> CreatedTenants { get; set; } = [];

    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTime.UtcNow;
    }

    public Result Validate()
    {
        var validator = new UserValidator();

        var validationResult = validator.Validate(this);

        return validationResult.IsValid
            ? Result.Ok()
            : ValidatorFailure.Fail(validationResult.Errors);
    }
}
