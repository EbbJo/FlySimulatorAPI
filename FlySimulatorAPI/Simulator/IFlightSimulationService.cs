namespace FlySimulatorAPI.Simulator;

public interface IFlightSimulationService {
    /// <summary>
    /// Simulate a flight from the given setup parameters.
    /// </summary>
    /// <param name="setup">Set up parameters for the flight.</param>
    /// <returns>The result of the simulation.</returns>
    /// <exception cref="ArgumentException">If the given parameters are invalid
    /// or point to non-existing data.</exception>
    public FlightSimulationResult SimulateFlight(FlightSimulationSetup setup);
}