using Airport.Application;
using Airport.Infrastructure;
using Airport_API;
using Airport_API.Middlewar;
using Airport_API.Shared.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//var configurationBuilder = new ConfigurationBuilder()
  //  .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

string connectionString =builder.Configuration.GetConnectionString("DefaultConnection");
//string connectionString="DataSource =.; Initial Catalog = Airport; Integrated Security = True";

          


builder.Services
    .RegisterApplicationServices()
    .RegisterInfrastructureServices(connectionString)
    .RegisterPresentationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

var app = builder.Build();
app.UseGlobalException();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseLogUrl();

app.MapControllers();

app.Run();
