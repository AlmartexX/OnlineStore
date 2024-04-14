using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL;
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
        public static IServiceCollection ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineStoreDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
