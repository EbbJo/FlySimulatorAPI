namespace FlySimulatorAPI.Simulator;

/// <summary>
/// The results of a flight simulation.
/// </summary>
public record FlightSimulationResult {
    /// <summary>
    /// Distance in kilometers travelled during the flight.
    /// </summary>
    public double Distance { get; init; }
    /// <summary>
    /// Time in hours that the flight took.
    /// </summary>
    public double FlightTime { get; init; }
    /// <summary>
    /// Fuel in liters that the plane consumed during the flight.
    /// </summary>
    public double FuelConsumption { get; init; }
    /// <summary>
    /// Cost of paying for staff for the flight's duration.
    /// </summary>
    public decimal StaffCost { get; init; }
};