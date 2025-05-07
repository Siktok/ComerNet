using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Application.Main;
using Lyoko.ComerNet.Domain.Core;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Infrastructure.Data;
using Lyoko.ComerNet.Infrastructure.Interface;
using Lyoko.ComerNet.Infrastructure.Repository;
using Lyoko.ComerNet.Transversal.Common;
using Lyoko.ComerNet.Transversal.Logging;

namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionRefact(this IServiceCollection services, IConfiguration configuration)
        {

           
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));




            return services;
        }
    }
}
