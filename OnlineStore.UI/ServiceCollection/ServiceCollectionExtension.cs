using OnlineStore.DAL.Repositories.UnitOfWork;

namespace OnlineStore.UI.ServiceCollection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
