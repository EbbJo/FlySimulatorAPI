using FlySimulatorAPI.Models.Airport;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Plane;
using FlySimulatorAPI.Models.Plane.Types;
using FlySimulatorAPI.Models.Repository;
using FlySimulatorAPI.Simulator;
using Microsoft.AspNetCore.Mvc;

namespace FlySimulatorAPI;

/// <summary>
/// Extension for the <see cref="WebApplication"/> class to add
/// the API endpoints for this API.
/// </summary>
public static class Endpoints {
    public static void MapEndpoints(this WebApplication app) {
        var planesGroup = app.MapGroup("/planes");
        planesGroup.MapGet("/", GetPlanes).WithSummary("Get all planes.");
        planesGroup.MapGet("/{id:guid}", GetPlaneById).WithSummary("Get a plane by id.");
        
        planesGroup.MapPost("/AirLinerPlane",
            (Func<IRepository<Plane>, AirLinerPlane, Task<IResult>>)AddPlane);
        planesGroup.MapPost("/AmphibiousPlane",
            (Func<IRepository<Plane>, AmphibiousPlane, Task<IResult>>)AddPlane);
        planesGroup.MapPost("/GliderPlane",
            (Func<IRepository<Plane>, GliderPlane, Task<IResult>>)AddPlane);
        planesGroup.MapPost("/MilitaryPlane",
            (Func<IRepository<Plane>, MilitaryPlane, Task<IResult>>)AddPlane);
        
        var airportGroup = app.MapGroup("/airports");
        airportGroup.MapGet("/", GetAirports).WithSummary("Get all airports.");
        airportGroup.MapGet("/{id:guid}", GetAirportById).WithSummary("Get an airport by id.");
        
        var employeeGroup = app.MapGroup("/employees");
        employeeGroup.MapGet("/", GetEmployees).WithSummary("Get all employees.");
        employeeGroup.MapGet("/{id:guid}", GetEmployeeById).WithSummary("Get an employee by id.");

        var flightSimGroup = app.MapGroup("/flight");
        flightSimGroup.MapPost("/", SimulateFlight).WithSummary("Simulate flight.");
    }

    private static Task<IResult> GetPlanes(IRepository<Plane> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
    }

    private static Task<IResult> GetPlaneById(IRepository<Plane> repo, [FromRoute] Guid id) {
        var plane = repo.GetById(id);

        return plane == null ?
            Task.FromResult<IResult>(TypedResults.NotFound()) :
            Task.FromResult<IResult>(TypedResults.Ok(plane));
    }

    private static Task<IResult> AddPlane(IRepository<Plane> repo, [FromBody] AirLinerPlane plane)
        => AddPlane(repo, plane as Plane);

    private static Task<IResult> AddPlane(IRepository<Plane> repo, [FromBody] AmphibiousPlane plane)
        => AddPlane(repo, plane as Plane);

    private static Task<IResult> AddPlane(IRepository<Plane> repo, [FromBody] GliderPlane plane)
        => AddPlane(repo, plane as Plane);

    private static Task<IResult> AddPlane(IRepository<Plane> repo, [FromBody] MilitaryPlane plane)
        => AddPlane(repo, plane as Plane);

    private static Task<IResult> AddPlane(IRepository<Plane> repo, Plane plane) {
        repo.Add(plane);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Ok(plane));
    }
    
    private static Task<IResult> GetAirports(IRepository<Airport> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
    }
    
    private static Task<IResult> GetAirportById(IRepository<Airport> repo, [FromRoute] Guid id) {
        var airport = repo.GetById(id);

        return airport == null ?
            Task.FromResult<IResult>(TypedResults.NotFound()) :
            Task.FromResult<IResult>(TypedResults.Ok(airport));
    }
    
    private static Task<IResult> GetEmployees(IRepository<Employee> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
    }
    
    private static Task<IResult> GetEmployeeById(IRepository<Employee> repo, [FromRoute] Guid id) {
        var employee = repo.GetById(id);

        return employee == null ?
            Task.FromResult<IResult>(TypedResults.NotFound()) :
            Task.FromResult<IResult>(TypedResults.Ok(employee));
    }

    private static Task<IResult> SimulateFlight(IFlightSimulationService simulator, [FromBody] FlightSimulationSetup setup) {
        try {
            Console.WriteLine(setup);
            var result = simulator.SimulateFlight(setup);
            return Task.FromResult<IResult>(TypedResults.Ok(result));
        }
        catch (ArgumentException e) {
            return Task.FromResult<IResult>(TypedResults.BadRequest(e.Message));
        }
        catch (Exception e) {
            return Task.FromResult<IResult>(TypedResults.InternalServerError(e.Message));
        }
    }
}