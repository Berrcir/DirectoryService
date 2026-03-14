using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrustructure.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgreSqlDevInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
         services
            .AddDbContext<DirectoryServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DirectoryServiceDb")!);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(CreateLoggerFactory());
            });

    public static IServiceCollection AddPostgreSqlProdInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
         services
            .AddDbContext<DirectoryServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DirectoryServiceDb")!);
                options.UseLoggerFactory(CreateLoggerFactory());
            });

    private static ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
}
