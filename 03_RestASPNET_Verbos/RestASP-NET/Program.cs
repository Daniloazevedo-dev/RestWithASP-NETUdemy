using Microsoft.EntityFrameworkCore;
using RestASP_NET.Model.Context;
using RestASP_NET.Services;
using RestASP_NET.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dependency Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();


var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(9, 2, 0));

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
