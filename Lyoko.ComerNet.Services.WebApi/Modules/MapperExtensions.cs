using Lyoko.ComerNet.Transversal.Mapper;

namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class MapperExtensions
    {

        public static IServiceCollection AddMapperRefact(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            return services;
        }

    }
}
