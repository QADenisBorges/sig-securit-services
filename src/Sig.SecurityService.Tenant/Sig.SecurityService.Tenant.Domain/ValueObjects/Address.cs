namespace Sig.SecurityServiceTenant.Domain.ValueObjects;

public class Address
{
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
    public string? Reference { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string PostalCode { get; set; }
}
