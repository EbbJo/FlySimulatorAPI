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
        /*
         * The multiple methods for different plane types is messy, but it's the best method I found to work,
         * when dealing with multiple implementations of the same class over HTML requests.
         *
         * I also did not design the databases to be asynchronous, so return values from request handlers
         * are a bit awkward sometimes.
         */
        
        /* PLANES */
        
        var planesGroup = app.MapGroup("/planes");
        //Create
        planesGroup.MapPost("/AirLinerPlane",
            (Func<IRepository<Plane>, AirLinerPlane, Task<IResult>>)AddPlane).WithSummary("Add an AirLiner plane.");
        planesGroup.MapPost("/AmphibiousPlane",
            (Func<IRepository<Plane>, AmphibiousPlane, Task<IResult>>)AddPlane).WithSummary("Add an Amphibious plane.");
        planesGroup.MapPost("/GliderPlane",
            (Func<IRepository<Plane>, GliderPlane, Task<IResult>>)AddPlane).WithSummary("Add a Glider plane.");
        planesGroup.MapPost("/MilitaryPlane",
            (Func<IRepository<Plane>, MilitaryPlane, Task<IResult>>)AddPlane).WithSummary("Add a Military plane.");
        //Read
        planesGroup.MapGet("/", GetPlanes).WithSummary("Get all planes.");
        planesGroup.MapGet("/{id:guid}", GetPlaneById).WithSummary("Get a plane by id.");
        //Update
        planesGroup.MapPut("/AirLinerPlane/{id:guid}",
            (Func<IRepository<Plane>, Guid, AirLinerPlane, Task<IResult>>)UpdatePlane).WithSummary("Update an AirLiner plane.");
        planesGroup.MapPut("/AmphibiousPlane/{id:guid}",
            (Func<IRepository<Plane>, Guid, AmphibiousPlane, Task<IResult>>)UpdatePlane).WithSummary("Update an Amphibious plane.");
        planesGroup.MapPut("/GliderPlane/{id:guid}",
            (Func<IRepository<Plane>, Guid, GliderPlane, Task<IResult>>)UpdatePlane).WithSummary("Update a Glider plane.");
        planesGroup.MapPut("/MilitaryPlane/{id:guid}",
            (Func<IRepository<Plane>, Guid, MilitaryPlane, Task<IResult>>)UpdatePlane).WithSummary("Update a Military plane.");
        //Delete
        planesGroup.MapDelete("/{id:guid}", DeletePlane).WithSummary("Delete a plane.");
        
        /* AIRPORTS */
        
        var airportGroup = app.MapGroup("/airports");
        //Create
        airportGroup.MapPost("/", AddAirport).WithSummary("Add an Airport.");
        //Read
        airportGroup.MapGet("/", GetAirports).WithSummary("Get all airports.");
        airportGroup.MapGet("/{id:guid}", GetAirportById).WithSummary("Get an airport by id.");
        //Update
        airportGroup.MapPut("/{id:guid}", UpdateAirport).WithSummary("Update an Airport.");
        //Delete
        airportGroup.MapDelete("/{id:guid}", DeleteAirport).WithSummary("Delete a airport.");
        
        /* EMPLOYEES */
        
        var employeeGroup = app.MapGroup("/employees");
        //Create
        employeeGroup.MapPost("/", AddEmployee).WithSummary("Add an Employee.");
        //Read
        employeeGroup.MapGet("/", GetEmployees).WithSummary("Get all employees.");
        employeeGroup.MapGet("/{id:guid}", GetEmployeeById).WithSummary("Get an employee by id.");
        //Update
        employeeGroup.MapPut("/{id:guid}", UpdateEmployee).WithSummary("Update an Employee.");
        //Delete
        employeeGroup.MapDelete("/{id:guid}", DeleteEmployee).WithSummary("Delete a employee.");
        
        /* SIMULATION */
        
        var flightSimGroup = app.MapGroup("/flight");
        flightSimGroup.MapPost("/", SimulateFlight).WithSummary("Simulate flight.");
    }

    /* PLANES */
    
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

    //General method of all plane types
    private static Task<IResult> AddPlane(IRepository<Plane> repo, [FromBody] Plane plane) {
        repo.Add(plane);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Created("planes/"+plane.Id, plane));
    }

    private static Task<IResult> UpdatePlane(IRepository<Plane> repo, [FromRoute] Guid id, [FromBody] AirLinerPlane plane)
        => UpdatePlane(repo, id, plane as Plane);

    private static Task<IResult> UpdatePlane(IRepository<Plane> repo, [FromRoute] Guid id, [FromBody] AmphibiousPlane plane)
        => UpdatePlane(repo, id, plane as Plane);

    private static Task<IResult> UpdatePlane(IRepository<Plane> repo, [FromRoute] Guid id, [FromBody] GliderPlane plane)
        => UpdatePlane(repo, id, plane as Plane);

    private static Task<IResult> UpdatePlane(IRepository<Plane> repo, [FromRoute] Guid id, [FromBody] MilitaryPlane plane)
        => UpdatePlane(repo, id, plane as Plane);

    //General method for all plane types
    private static Task<IResult> UpdatePlane(IRepository<Plane> repo, [FromRoute] Guid id, [FromBody] Plane plane) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Update(id, plane);
        repo.SaveChanges();

        return Task.FromResult<IResult>(TypedResults.Ok(plane));
    }

    private static Task<IResult> DeletePlane(IRepository<Plane> repo, [FromRoute] Guid id) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Delete(id);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Ok());
    }
    
    /* AIRPORTS */
    
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
    
    private static Task<IResult> AddAirport(IRepository<Airport> repo, [FromBody] Airport airport) {
        repo.Add(airport);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Created("airports/"+airport.Id, airport));
    }
    
    private static Task<IResult> UpdateAirport(IRepository<Airport> repo, [FromRoute] Guid id, [FromBody] Airport airport) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Update(id, airport);
        repo.SaveChanges();

        return Task.FromResult<IResult>(TypedResults.Ok(airport));
    }
    
    private static Task<IResult> DeleteAirport(IRepository<Airport> repo, [FromRoute] Guid id) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Delete(id);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Ok());
    }
    
    /* EMPLOYEES */
    
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
    
    private static Task<IResult> AddEmployee(IRepository<Employee> repo, [FromBody] Employee employee) {
        repo.Add(employee);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Created("employees/"+employee.Id, employee));
    }
    
    private static Task<IResult> UpdateEmployee(IRepository<Employee> repo, [FromRoute] Guid id, [FromBody] Employee employee) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Update(id, employee);
        repo.SaveChanges();

        return Task.FromResult<IResult>(TypedResults.Ok(employee));
    }
    
    private static Task<IResult> DeleteEmployee(IRepository<Employee> repo, [FromRoute] Guid id) {
        if (repo.GetById(id) == null)
            return Task.FromResult<IResult>(TypedResults.NotFound());
        
        repo.Delete(id);
        repo.SaveChanges();
        
        return Task.FromResult<IResult>(TypedResults.Ok());
    }

    /* SIMULATION */
    
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