using FlySimulatorAPI.Models.Airport;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Plane;
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
        
        var airportGroup = app.MapGroup("/airports");
        airportGroup.MapGet("/", GetAirports).WithSummary("Get all airports.");
        
        var employeeGroup = app.MapGroup("/employees");
        employeeGroup.MapGet("/", GetEmployees).WithSummary("Get all employees.");

        var flightSimGroup = app.MapGroup("/flight");
        flightSimGroup.MapPost("/", SimulateFlight).WithSummary("Simulate flight.");
    }

    private static Task<IResult> GetPlanes(IRepository<Plane> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
    }
    
    private static Task<IResult> GetAirports(IRepository<Airport> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
    }
    
    private static Task<IResult> GetEmployees(IRepository<Employee> repo) {
        var list = repo.GetAll();
        
        return Task.FromResult<IResult>(TypedResults.Ok(list));
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