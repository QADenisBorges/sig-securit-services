using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.Domain.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sig.SecurityServiceTenant.Domain.ValueObjects;

[Owned]
public sealed class Document
{
    public string Number { get; set; }

    [NotMapped]
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
