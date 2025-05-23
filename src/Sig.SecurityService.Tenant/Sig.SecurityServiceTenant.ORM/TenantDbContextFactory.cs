using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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

        var connectionStringKey = "DbSecurityServiceTenant";
        var connectionString = configuration.GetConnectionString(connectionStringKey);

        if (string.IsNullOrEmpty(connectionStringKey))
        {
            Console.WriteLine("Connection string not found!");
        }

        builder.UseSqlServer(
            connectionString,
            sqlServer => sqlServer.MigrationsAssembly("Sig.SecurityServiceTenant.ORM")
        );

        return new TenantDbContext(builder.Options);
    }
}
