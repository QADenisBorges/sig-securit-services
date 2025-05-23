using MediatR;
using Sig.SecurityServiceTenant.Domain.Entities;

namespace Sig.SecurityServiceTenant.Services.UseCases.Plans.CreatePlan;

public record class CreatePlanCommand(Plan Plan) : IRequest<Plan>
{
}
