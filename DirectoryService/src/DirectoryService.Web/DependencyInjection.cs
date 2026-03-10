namespace DirectoryService.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProgramDependencies(this IServiceCollection services) =>
            services.AddWebDependencies();

        public static IServiceCollection AddWebDependencies(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            return services;
        }
    }
}
