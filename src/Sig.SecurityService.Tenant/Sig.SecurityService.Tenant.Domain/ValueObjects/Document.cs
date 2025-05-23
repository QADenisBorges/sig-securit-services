using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Enuns;

namespace Sig.SecurityServiceTenant.Domain.ValueObjects;

[Owned]
public sealed class Document
{
    public string Number { get; set; }
    public DocumentType Type 
    { 
        get => Number.Length switch
        {
            11 => DocumentType.CPF,
            14 => DocumentType.CNPJ,
            _ => throw new ArgumentException("Invalid length document number")
        };
    }
}
