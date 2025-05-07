using Lyoko.ComerNet.Transversal.Common;
using Lyoko.ComerNet.Transversal.Mapper;
using Lyoko.ComerNet.Infrastructure.Data;
using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Application.Main;
using Lyoko.ComerNet.Domain;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Domain.Core;
using Lyoko.ComerNet.Infrastructure.Interface;
using Lyoko.ComerNet.Infrastructure.Repository;
using Microsoft.OpenApi.Models;
using Lyoko.ComerNet.Services.WebApi.Helper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Lyoko.ComerNet.Transversal.Logging;
using System.Runtime.CompilerServices;
using Lyoko.ComerNet.Services.WebApi.Modules;
using Lyoko.ComerNet.Application.Validator;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerRefact();

builder.Services.AddMapperRefact();

builder.Services.AddFeaturesRefact(builder.Configuration);

builder.Services.AddMvc().AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.PropertyNamingPolicy = null;  //no cambia los nombres de las propiedades a camelCase
     options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;  // Ignorar valores nulos
 });


builder.Services.AddInjectionRefact(builder.Configuration);

builder.Services.AddAuthenticationRefact(builder.Configuration);
builder.Services.AddValidators();





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi api");
    });

}
app.UseCors("policyApiComerNet");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
