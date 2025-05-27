using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sig.SecurityService.Tenant.Common.FluentResults;
using Sig.SecurityService.Tenant.Common.FluentResults.CustomErrors;
using Sig.SecurityServiceTenant.Services.UseCases.Tenants.CreateTenant;
using Sig.SecurityServiceTenant.WebApi.Common;
using Sig.SecurityServiceTenant.WebApi.Features.Tenants.CreateTenant;

namespace Sig.SecurityServiceTenant.WebApi.Features.Tenants
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController(IMediator mediator, IMapper mapper) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateTenantRequest request)
        {
            var validate = new CreateTenantValidator().Validate(request);
            if (!validate.IsValid)
                return HandleFailure(ValidatorFailure.Fail(validate.Errors));

            var createTenantCommand = mapper.Map<CreateTenantCommand>(request);
            var tenantCreated = await mediator.Send(createTenantCommand);

            var response = tenantCreated.Match(
                onSuccess: success =>
                {
                    var response = mapper.Map<CreateTenantResponse>(success);
                    return Result.Ok(response);
                },
                onFailure: errors => errors.FirstOrDefault() switch
                {
                    ValidatorFailure validator => new ExceptionalFailure(
                        validator.Code,
                        validator.Message,
                        [.. validator.Errors]),

                    _ => Result.Fail(errors)
                });

            return HandleResult(response);
        }

        [HttpPost]
        [Route("dois")]
        public async Task<IActionResult> Create2(CreateTenantRequest request)
        {
            var validate = new CreateTenantValidator().Validate(request);
            if (!validate.IsValid)
                return HandleFailure(ValidatorFailure.Fail(validate.Errors));

            var createTenantCommand = mapper.Map<CreateTenantCommand>(request);
            var createResult = await mediator.Send(createTenantCommand);

            if(createResult.IsSuccess)
            {
                var responseSuccess = mapper.Map<CreateTenantResponse>(createResult.Value);
                return Ok(responseSuccess);
            }

            var error = createResult.Errors.FirstOrDefault();
            var responseError = error switch
            {
                ValidatorFailure validator => new ExceptionalFailure(
                        validator.Code,
                        validator.Message,
                        [.. validator.Errors]),

                _ => Result.Fail(createResult.Errors)
            };

            return HandleResult(responseError);
        }
    }
}
