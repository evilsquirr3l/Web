using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Implementation.Automapper
{
    public static class MapperServiceExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}