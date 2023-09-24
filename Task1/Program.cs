using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Task1.Repository;


var policyName = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add your dependency injection for the database connection hereSystem.IO.InvalidDataException: 'Failed to load configuration from file 'C:\Users\imran\source\repos\Task1\Task1\appsettings.json'.'

builder.Services.AddSingleton<IDbConnection>((sp) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyOrigin()
                            .WithMethods("GET")
                            .AllowAnyHeader();
                      });
});

builder.Services.AddScoped<EmployeeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors(policyName);


app.UseAuthorization();

app.MapControllers();

app.Run();
