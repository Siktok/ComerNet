//using Microsoft.Testing.Platform.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Identity;
using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Application.Main;
using Lyoko.ComerNet.Domain.Core;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Application.Validator;
using Lyoko.ComerNet.Infrastructure.Interface;
using Lyoko.ComerNet.Infrastructure.Repository;
using Lyoko.ComerNet.Transversal.Mapper;

namespace Lyoko.ComerNet.Apliccation.Test
{
    [TestClass]
    public sealed class UsersApliccarionTest
    {

        public static IConfiguration _configuration;
        public static IServiceScopeFactory _serviceFactory;

        [ClassInitialize]
        public static void Inicialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",  true,  true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();
          
            services.AddTransient<IUsersApplication, UsersApplication>();
      

            _serviceFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();

        }

        [TestMethod]
        public void Authenticate_cuandoNoSeEnvianParametros_ErrorValidacion()
        {
            using var scope= _serviceFactory.CreateScope();
          //  var context = scope.ServiceProvider.GetService<IUsersApplication>;
            var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

            //Arrange
            var username = string.Empty;
            var password = string.Empty;
            var expected = "Error de validación";

            //Act
            var result = context.Authenticate(username, password);
            var actual= result.Message;

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
