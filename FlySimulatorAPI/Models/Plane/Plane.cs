using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Plane;

public abstract class Plane {
    [Key]
    public Guid Id { get; set; }
    
    public virtual PlaneType Type => PlaneType.None;

    /// <summary>
    /// The weight of the plane with no cargo/passengers.
    /// </summary>
    [Required]
    public double BaseWeight { get; set; } = 0d;
    
    [Required]
    public string ModelName { get; set; } = string.Empty;
    
    /// <summary>
    /// Km/h
    /// </summary>
    [Required]
    public double TopSpeed { get; set; } = 0d;

    protected Plane() {
        Id = Guid.NewGuid();
    }

    protected Plane(string modelName, double baseWeight, double topSpeed) : this() {
        ModelName = modelName;
        BaseWeight = baseWeight;
        TopSpeed = topSpeed;
    }

    public virtual double FuelOverDistance(double km) {
        return 0d;
    }

    public virtual double FuelOverDistance(params GpsCoordinates[] coords) {
        return 0d;
    }
}