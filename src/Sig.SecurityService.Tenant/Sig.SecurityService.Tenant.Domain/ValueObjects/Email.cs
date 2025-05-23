using Microsoft.EntityFrameworkCore;

namespace Sig.SecurityServiceTenant.Domain.ValueObjects;

[Owned]
public sealed class Email
{
    public string Address { get; set; }

    public Email(string address)
    {
        Address = address;
    }
}
