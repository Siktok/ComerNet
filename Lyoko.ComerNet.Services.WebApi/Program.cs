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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { 
        Title = "ComerNet Services API",
        Version = "v1",
        Description = "WebApi de estudio",
        Contact = new OpenApiContact
        {
            Name = "Azael Llanos",
            Email = "azael1992sp@gmail.com",
            Url =  new Uri("https://www.linkedin.com/in/azael-llanos-gonzalez/")
            
        }
     
    });
});
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

//(net<6)builder.Services.AddMvc().AddJsonOptions(Options => { Options.JsonSerializerOptions = Newtonsoft.Json.Serialization.DefaulContractResolver(); })
builder.Services.AddMvc().AddJsonOptions(options =>
 {
    
     options.JsonSerializerOptions.PropertyNamingPolicy = null;  //para que no cambie los nombres de las propiedades a camelCase
     options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;  // Ignorar valores nulos
 });
//Inyección de dependencias aplicacion
//(net<6)builder.Services.AddSingleton<IConfiguration, ConnectionFactory>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
