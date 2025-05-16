namespace Sig.SecurityServiceTenant.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn => DateTime.UtcNow;
}
