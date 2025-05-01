using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Engine;

public class EngineParameters {
    /// <summary>
    /// Liters
    /// </summary>
    [Required]
    public double FuelCapacity { get; set; } = 0d;

    /// <summary>
    /// Liters per kilometer
    /// </summary>
    [Required]
    public double FuelEfficiency { get; set; } = 0d;
}