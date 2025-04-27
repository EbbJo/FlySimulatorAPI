using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Plane;

public abstract class Plane {
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// The weight of the plane with no cargo/passengers.
    /// </summary>
    public double BaseWeight { get; set; }

    public string ModelName { get; set; } = string.Empty;
}