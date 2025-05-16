using Microsoft.EntityFrameworkCore;

namespace Sig.SecurityServiceTenant.Domain.ObjectValues;

[Owned]
public sealed class Email
{
    public required string Address { get; set; }
}
