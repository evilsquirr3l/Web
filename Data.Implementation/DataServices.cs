using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Implementation
{
    public static class DataServices
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ProductionDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ProductionDbContext>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}