using Lyoko.ComerNet.Services.WebApi.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationRefact(this IServiceCollection services, IConfiguration configuration)
        {

            var appsettingSeccion = configuration.GetSection("Config");
            services.Configure<AppSettings>(appsettingSeccion);

            var key = Encoding.ASCII.GetBytes(appsettingSeccion.GetSection("Secret").Value);
            var Issuer = appsettingSeccion.GetSection("Issuer").Value;
            var Audience = appsettingSeccion.GetSection("Audience").Value;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var UserId = int.Parse(context.Principal.Identity.Name);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = Issuer,
                    ValidateAudience = true,
                    ValidAudience = Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            return services;
        }

    }
}
