namespace FlySimulatorAPI.Simulator;

/// <summary>
/// Setup information for a flight simulation.
/// </summary>
public record FlightSimulationSetup {
    /// <summary>
    /// Plane to be flying the route.
    /// </summary>
    public Guid Plane { get; init; }
    /// <summary>
    /// List of employees involved.
    /// </summary>
    public Guid[] Employees { get; init; } = [];
    /// <summary>
    /// List of airports to travel to and from (in order).
    /// </summary>
    public Guid[] AirportRoute { get; init; } = [];
    /// <summary>
    /// Number of passengers (if any).
    /// </summary>
    public int PassengerCount { get; init; } = 0;
    /// <summary>
    /// Weight (kg) of the cargo (if any).
    /// </summary>
    public double CargoWeight { get; init; } = 0d;
}