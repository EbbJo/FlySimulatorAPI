namespace FlySimulatorAPI.Simulator;

public interface IFlightSimulator {
    public FlightSimulationResult SimulateFlight(FlightSimulationSetup setup);
}