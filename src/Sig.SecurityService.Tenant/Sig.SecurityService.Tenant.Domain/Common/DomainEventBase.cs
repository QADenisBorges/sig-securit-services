namespace Sig.SecurityServiceTenant.Domain.Common;

public abstract class DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
}