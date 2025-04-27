namespace FlySimulatorAPI.Models.Plane;

public interface IEnginePowered {
    /// <summary>
    /// Liters
    /// </summary>
    public double FuelCapacity { get; set; }
    
    /// <summary>
    /// Liters per kilometer
    /// </summary>
    public double FuelEfficiency { get; set; }
}