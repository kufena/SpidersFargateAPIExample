using Microsoft.AspNetCore.Hosting;
using FargateWebAPI.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var environment = context.HostingEnvironment.EnvironmentName.ToLower();
    Console.WriteLine($"ENVIRONMENT = {environment}");
    config.AddSystemsManager($"/{environment}");
});

// Loads parameters, either from appsettings.json "Parameters" section, or /{environment}/Parameters in SSM Parameter Store.
builder.Services.Configure<Parameters>(builder.Configuration.GetSection("Parameters"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
