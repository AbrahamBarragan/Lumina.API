using Lumina.Application.Features.Meters;
using Lumina.Application.Features.Readings;
using Lumina.Domain.Services;
using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<LuminaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<ElectricityRateOptions>(
    builder.Configuration.GetSection("ElectricityRate"));

builder.Services.AddScoped<IReadingRepository, ReadingRepository>();
builder.Services.AddScoped<IMeterRepository, MeterRepository>();
builder.Services.AddScoped<ConsumptionCalculator>();
builder.Services.AddScoped<ConsumptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
