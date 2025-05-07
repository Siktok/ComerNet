using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Lyoko.ComerNet.Services.WebApi.Modules
{
    public static class SwaggerExtensiones
    {
        public static IServiceCollection AddSwaggerRefact(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ComerNet Services API",
                    Version = "v1",
                    Description = "WebApi de estudio",
                    Contact = new OpenApiContact
                    {
                        Name = "Azael Llanos",
                        Email = "azael1992sp@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/azael-llanos-gonzalez/")

                    }

                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Inserta solo el JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }


                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() { } }
                });


            });
            return services;
        }
    }
}
