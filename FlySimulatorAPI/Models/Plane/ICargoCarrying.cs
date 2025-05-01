using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Plane;

public interface ICargoCarrying {
    [Required]
    public double CargoWeightCapacity { get; set; }
}