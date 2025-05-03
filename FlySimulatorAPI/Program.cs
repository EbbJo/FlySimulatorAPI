using FlySimulatorAPI;
using FlySimulatorAPI.Models.Airport;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Plane;
using FlySimulatorAPI.Models.Repository;
using FlySimulatorAPI.Models.Repository.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

/*
 * This "database" is backed by XML. Objects are serialized and deserialized
 * to simulate the traditional ORM of DbContext services.
 * 
 * An alternative would probably be to just use SQLite.
 */

//Planes
builder.Services.AddScoped<IXmlMediator<XmlPlaneList>, XmlMediator<XmlPlaneList>>();
builder.Services.AddScoped<IRepository<Plane>, PlaneXmlRepository>();

//Airports
builder.Services.AddScoped<IXmlMediator<XmlAirportList>, XmlMediator<XmlAirportList>>();
builder.Services.AddScoped<IRepository<Airport>, AirportXmlRepository>();

//Employees
builder.Services.AddScoped<IXmlMediator<XmlEmployeeList>, XmlMediator<XmlEmployeeList>>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeXmlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

//Ensure there is data in the repositories
SeedData.EnsurePopulated();

//Map the API endpoints
app.MapEndpoints();

app.Run();