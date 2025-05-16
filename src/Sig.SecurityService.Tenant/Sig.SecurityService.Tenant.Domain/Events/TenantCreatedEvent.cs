using Sig.SecurityServiceTenant.Domain.Common;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Domain.Events;

public sealed record TenantCreatedEvent(
    Guid TenantId,
    string Name,
    string Cnpj,
    string Slug
) : IDomainEvent;

