using Domain.Models;
using Repository;
using Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddScoped<IRepositoryClass, RepositoryClass>()
    .AddScoped<IServiceClass, ServiceClass>()

    //.AddTransient<IRepositoryClass, RepositoryClass>()
    //.AddTransient<IServiceClass, ServiceClass>()

    //.AddSingleton<IRepositoryClass, RepositoryClass>()
    //.AddSingleton<IServiceClass, ServiceClass>()

    .AddSingleton<ValueSingleton>()
    .AddScoped<ValueScoped>()
    .AddTransient<ValueTransient>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    ;

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
