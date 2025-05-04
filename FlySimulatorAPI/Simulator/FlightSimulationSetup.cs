namespace FlySimulatorAPI.Simulator;

public record FlightSimulationSetup {
    public Guid Plane { get; init; }
    public Guid[] Employees { get; init; } = [];
    public Guid[] AirportRoute { get; init; } = [];
}