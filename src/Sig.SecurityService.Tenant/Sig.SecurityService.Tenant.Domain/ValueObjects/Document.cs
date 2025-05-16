using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Enuns;

namespace Sig.SecurityServiceTenant.Domain.ObjectValues;

[Owned]
public sealed class Document
{
    public string Number { get; set; }
    public DocumentType Type { get; set; }
}
