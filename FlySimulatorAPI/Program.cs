using FlySimulatorAPI.Models.Plane;
using FlySimulatorAPI.Models.Repository;
using FlySimulatorAPI.Models.Repository.Xml;
using Microsoft.AspNetCore.DataProtection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IRepository<Plane>, PlaneXmlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

SeedData.EnsurePopulated();

app.Run();