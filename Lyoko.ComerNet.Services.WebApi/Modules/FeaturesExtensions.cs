namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class FeaturesExtensions
    {
        public static IServiceCollection AddFeaturesRefact(this IServiceCollection services, IConfiguration configuration)
        {


            //Habilitación políticas CORS
            services.AddCors(options =>
            {
                options.AddPolicy("policyApiComerNet",
                    policy =>
                    {
                        var allowedOrigins = configuration.GetSection("Config").GetSection("OriginCors").Value;
                        policy.WithOrigins(allowedOrigins);
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
          


            return services;
        }
    }
}
