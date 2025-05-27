using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sig.SecurityServiceTenant.Domain.Interfaces;
using Sig.SecurityServiceTenant.ORM.Repositories;

namespace Sig.SecurityServiceTenant.ORM.DependencyInjectors;

public static class Dependency
{
    public static WebApplicationBuilder InfrastructureModuleInitializer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITenantRepository, TenantRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        return builder;
    }
}
