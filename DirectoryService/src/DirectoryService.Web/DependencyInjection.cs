using DirectoryService.Infrustructure.PostgreSql;

namespace DirectoryService.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddPostgreSqlInfrastructure(builder.Configuration, builder.Environment);

            return services;
        }
    }
}
