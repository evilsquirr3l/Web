using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Automapper
{
    public static class MapperServiceExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);

            return services;
        }
    }
}