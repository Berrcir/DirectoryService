using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrustructure.PostgreSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgreSqlInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment) =>
         services
            .AddDbContext<DirectoryServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DirectoryServiceDb")!);
                options.UseLoggerFactory(CreateLoggerFactory());

                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });

    private static ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
}
