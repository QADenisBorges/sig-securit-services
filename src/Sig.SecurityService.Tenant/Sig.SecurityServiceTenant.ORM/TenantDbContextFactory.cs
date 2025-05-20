using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Sig.SecurityServiceTenant.ORM;

public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
{
    public TenantDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Sig.SecurityServiceTenant.WebApi");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TenantDbContext>();
        var connectionString = configuration.GetConnectionString("DbSecurityServiceTenant"); // Corrigido aqui

        builder.UseSqlServer(
            
        sqlServer => sqlServer.MigrationsAssembly("Sig.SecurityServiceTenant.ORM")
        );

        return new TenantDbContext(builder.Options);
    }
}
