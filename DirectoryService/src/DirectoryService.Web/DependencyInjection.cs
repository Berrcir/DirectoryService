using DirectoryService.Infrustructure.PostgreSql;

namespace DirectoryService.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            if (builder.Environment.IsDevelopment())
            {
                services.AddPostgreSqlDevInfrastructure(builder.Configuration);
            }
            else
            {
                services.AddPostgreSqlProdInfrastructure(builder.Configuration);
            }

            return services;
        }
    }
}
