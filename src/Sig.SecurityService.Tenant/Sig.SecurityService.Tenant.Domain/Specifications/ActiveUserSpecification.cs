using Ambev.DeveloperEvaluation.Domain.Enums;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
