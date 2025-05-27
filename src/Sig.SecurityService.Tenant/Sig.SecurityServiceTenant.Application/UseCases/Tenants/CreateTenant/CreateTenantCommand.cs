using FluentResults;
using MediatR;
using Sig.SecurityServiceTenant.Application.UseCases.Tenants.CreateTenant;

namespace Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;

public sealed class CreateTenantCommand : IRequest<Result<CreateTenantResult>>
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Email { get; set; }
    public required int DddPhone { get; set; }
    public required long Phone { get; set; }
    public int? DddWhatsappPhone { get; set; }
    public long? WhatsappPhone { get; set; }
    public required Guid CreateByUserId { get; set; }
}
