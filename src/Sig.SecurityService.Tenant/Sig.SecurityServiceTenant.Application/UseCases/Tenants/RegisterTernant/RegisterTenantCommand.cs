using FluentResults;
using MediatR;

namespace Sig.SecurityServiceTenant.Application.UseCases.Tenants.RegisterTernant;

public class RegisterTenantCommand : IRequest<Result<RegisterTenantResult>>
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Email { get; set; }
    public required int DddPhone { get; set; }
    public required long Phone { get; set; }
    public int? DddWhatsappPhone { get; set; }
    public long? WhatsappPhone { get; set; }
    public Guid PlanId { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public required string Complement { get; set; }
    public string? Reference { get; set; }
    public required string DistrictId { get; set; }
    public required string CityId { get; set; }
    public required string StateId { get; set; }
    public required string PostalCode { get; set; }
    public string CountryId { get; set; }
}
