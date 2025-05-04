using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Airport;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Plane;
using FlySimulatorAPI.Models.Repository;

namespace FlySimulatorAPI.Simulator;

public class FlightSimulator : IFlightSimulator {
    private IRepository<Plane> _planeRepository;
    private IRepository<Employee> _employeeRepository;
    private IRepository<Airport> _airportRepository;

    public FlightSimulator(IRepository<Plane> planeRepository, IRepository<Employee> employeeRepository,
        IRepository<Airport> airportRepository) {
        _planeRepository = planeRepository;
        _employeeRepository = employeeRepository;
        _airportRepository = airportRepository;
    }
    
    public FlightSimulationResult SimulateFlight(FlightSimulationSetup setup) {
        //We need at least two points to move between in order to simulate a flight.
        if (setup.AirportRoute.Length < 2)
            throw new Exception("The airport route must have at least 2 points.");
        
        //Get plane
        Plane? plane = _planeRepository.GetById(setup.Plane);
        if (plane == null)
            throw new Exception($"Plane {setup.Plane} does not exist.");

        //Get employees
        List<Employee> employees = new(setup.Employees.Length);

        foreach (var id in setup.Employees) {
            Employee? employee = _employeeRepository.GetById(id);

            if (employee == null)
                throw new Exception($"Employee {id} does not exist.");
            
            employees.Add(employee);
        }
        
        //Get airports
        List<Airport> airports = new(setup.AirportRoute.Length);
        
        foreach (var id in setup.AirportRoute) {
            Airport? airport = _airportRepository.GetById(id);

            if (airport == null)
                throw new Exception($"Airport {id} does not exist.");
            
            airports.Add(airport);
        }
        
        return SimulateFlight(plane, employees, airports);
    }

    public static FlightSimulationResult SimulateFlight(Plane plane, List<Employee> employees, List<Airport> airports) {
        //Get the geo points for the route
        var points = airports.Select(airport => airport.Position).ToArray();

        //Calculate the total distance of the flight
        double distance = GpsCoordinates.ChainDistKm(points);
        Console.WriteLine(distance);

        //Calculate time (we just assume top speed throughout the whole thing)
        double flightTime = distance / plane.TopSpeed;
        Console.WriteLine(flightTime);
        
        //Calculate fuel consumption
        double fuelConsumption = plane.FuelOverDistance(distance);
        Console.WriteLine(fuelConsumption);
        
        //Calculate staff cost
        decimal staffCost = employees.Sum(employee => employee.Salary * (decimal)flightTime);
        Console.WriteLine(staffCost);
        
        return new FlightSimulationResult {
            Distance = distance,
            FlightTime = flightTime,
            FuelConsumption = fuelConsumption,
            StaffCost = staffCost
        };
    }
}