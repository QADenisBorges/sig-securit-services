using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sig.SecurityServiceTenant.ORM;
using Sig.SecurityServiceTenant.ORM.DependencyInjectors;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TenantDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbSecurityServiceTenant")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.InfrastructureModuleInitializer();

builder.Services.AddAutoMapper(
    typeof(Program).Assembly, 
    typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Security API",
        Version = "v1",
        Description = "Documentação da API",
        Contact = new OpenApiContact
        {
            Name = "Denis Borges",
            Email = "qadenisborges@gmail.com"
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
