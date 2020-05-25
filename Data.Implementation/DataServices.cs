using Data.Abstraction;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 4;
                    opt.Password.RequireDigit = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ProductionDbContext>();
            
            return services;
        }
    }
}