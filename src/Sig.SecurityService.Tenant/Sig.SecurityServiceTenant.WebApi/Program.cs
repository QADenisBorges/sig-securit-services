using Microsoft.EntityFrameworkCore;
using Sig.SecurityServiceTenant.ORM;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TenantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbSecutiryServiceTenant")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
