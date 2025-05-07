using Lyoko.ComerNet.Application.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
            return services;
        }

    }
}
