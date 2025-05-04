namespace FlySimulatorAPI.Simulator;

public record FlightSimulationSetup {
    public Guid Plane { get; init; }
    public Guid[] Employees { get; init; } = [];
    public Guid[] AirportRoute { get; init; } = [];
    public int PassengerCount { get; init; } = 0;
    public double CargoWeight { get; init; } = 0d;
}