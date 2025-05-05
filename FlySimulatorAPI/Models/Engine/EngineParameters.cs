using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Engine;

[Serializable]
public class EngineParameters {
    /// <summary>
    /// Amount of fuel (liters) the tank can hold.
    /// </summary>
    [Required]
    public double FuelCapacity { get; set; } = 0d;

    /// <summary>
    /// Amount of liters consumed by the engine per kilometer travelled.
    /// </summary>
    [Required]
    public double FuelEfficiency { get; set; } = 0d;

    public override string ToString() {
        return $"FuelCapacity: {FuelCapacity}L, FuelEfficiency: {FuelEfficiency}L/km";
    }
}