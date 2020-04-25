using AutoMapper;
using Business.Abstraction;
using Business.Implementation.Automapper;
using Business.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Implementation
{
    public static class BusinessServices
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<IProductionService, ProductionService>();
            services.AddTransient<ITemplateService, TemplateService>();

            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}