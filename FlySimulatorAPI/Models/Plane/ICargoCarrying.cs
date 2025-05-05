using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Plane;

/// <summary>
/// Represents a plane that carries cargo.
/// </summary>
public interface ICargoCarrying {
    /// <summary>
    /// Amount of weight (kg) of cargo the plane can hold.
    /// </summary>
    [Required]
    public double CargoWeightCapacity { get; set; }
}