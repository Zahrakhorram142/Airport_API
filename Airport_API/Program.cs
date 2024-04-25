using Airport.Application;
using Airport.Infrastructure;
using Airport_API;
using Airport_API.Middlewar;
using Airport_API.Shared.Configs;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

string connectionString =builder.Configuration.GetConnectionString("DefaultConnection");
//string connectionString="DataSource =.; Initial Catalog = Airport; Integrated Security = True";

          
builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));


builder.Services
    .RegisterApplicationServices()
    .RegisterInfrastructureServices(connectionString)
    .RegisterPresentationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
