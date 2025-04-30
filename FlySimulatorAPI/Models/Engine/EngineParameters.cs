namespace FlySimulatorAPI.Models.Engine;

public class EngineParameters {
    /// <summary>
    /// Liters
    /// </summary>
    public double FuelCapacity { get; set; }
    
    /// <summary>
    /// Liters per kilometer
    /// </summary>
    public double FuelEfficiency { get; set; }
}