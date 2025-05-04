using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Airport;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Plane;
using FlySimulatorAPI.Models.Repository;

namespace FlySimulatorAPI.Simulator;

/// <summary>
/// Simulates flights.
/// </summary>
/// <param name="planeRepository">Repository of planes (dependency injected).</param>
/// <param name="employeeRepository">Repository of employees (dependency injected).</param>
/// <param name="airportRepository">Repository of airports (dependency injected).</param>
public class FlightSimulator(
    IRepository<Plane> planeRepository,
    IRepository<Employee> employeeRepository,
    IRepository<Airport> airportRepository)
    : IFlightSimulationService {
    
    public FlightSimulationResult SimulateFlight(FlightSimulationSetup setup) {
        //We need at least two points to move between in order to simulate a flight.
        if (setup.AirportRoute.Length < 2)
            throw new ArgumentException("The airport route must have at least 2 points.");
        
        //Get plane
        var plane = planeRepository.GetById(setup.Plane);
        if (plane == null)
            throw new ArgumentException($"Plane {setup.Plane} does not exist.");
        
        //Check that the plane can carry the passengers
        if (setup.PassengerCount > 0) {
            if (plane is not IPeopleCarrying carrying)
                throw new ArgumentException($"Plane {setup.Plane} is not of a type that carries passengers.");

            if (carrying.PassengerCapacity < setup.PassengerCount)
                throw new ArgumentException($"Plane {setup.Plane} can only carry {carrying.PassengerCapacity} passengers.");
        }
        
        //Check that the plane can carry the cargo
        if (setup.CargoWeight > 0d) {
            if (plane is not ICargoCarrying carrying)
                throw new ArgumentException($"Plane {setup.Plane} is not of a type that carries cargo.");
            
            if (carrying.CargoWeightCapacity < setup.CargoWeight)
                throw new ArgumentException($"Plane {setup.Plane} can only carry {carrying.CargoWeightCapacity}kg of cargo.");
        }
        
        //Get employees
        List<Employee> employees = new(setup.Employees.Length);

        foreach (var id in setup.Employees) {
            var employee = employeeRepository.GetById(id);

            if (employee == null)
                throw new ArgumentException($"Employee {id} does not exist.");
            
            employees.Add(employee);
        }
        
        //Get airports
        List<Airport> airports = new(setup.AirportRoute.Length);
        
        foreach (var id in setup.AirportRoute) {
            var airport = airportRepository.GetById(id);

            if (airport == null)
                throw new ArgumentException($"Airport {id} does not exist.");
            
            airports.Add(airport);
        }
        
        return SimulateFlight(plane, employees, airports);
    }

    /// <summary>
    /// Simulate a flight with the given parameters.
    /// </summary>
    /// <param name="plane">The plane that will be flying.</param>
    /// <param name="employees">The employees involved with the flight.</param>
    /// <param name="airports">The list of airports to fly between (in order).</param>
    /// <returns>The result of the simulation.</returns>
    public static FlightSimulationResult SimulateFlight(Plane plane, List<Employee> employees, List<Airport> airports) {
        //Get the geo points for the route
        var points = airports.Select(airport => airport.Position).ToArray();

        //Calculate the total distance of the flight
        double distance = GpsCoordinates.ChainDistKm(points);

        //Calculate time (we just assume top speed throughout the whole thing)
        double flightTime = distance / plane.TopSpeed;
        
        //Calculate fuel consumption
        double fuelConsumption = plane.FuelOverDistance(distance);
        
        //Calculate staff cost
        decimal staffCost = employees.Sum(employee => employee.Salary * (decimal)flightTime);
        
        return new FlightSimulationResult {
            Distance = distance,
            FlightTime = flightTime,
            FuelConsumption = fuelConsumption,
            StaffCost = staffCost
        };
    }
}