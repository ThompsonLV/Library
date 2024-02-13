namespace Library.API.Extensions
{
    public static class SeedWorkExtensions
    {
        public static IServiceCollection AddSeedWork(
            this IServiceCollection services)
        {
            services.AddScoped(
                typeof(IRepository<>),
                typeof(EntityFrameworkRepository<>));

            return services;
        }
    }
}