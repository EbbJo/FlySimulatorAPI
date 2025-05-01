using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Plane;

public abstract class Plane {
    [Key]
    public int Id { get; set; }
    
    public virtual PlaneType Type => PlaneType.None;

    /// <summary>
    /// The weight of the plane with no cargo/passengers.
    /// </summary>
    [Required]
    public double BaseWeight { get; set; } = 0d;
    
    [Required]
    public string ModelName { get; set; } = string.Empty;
    
    public Plane() {}

    protected Plane(string modelName, double baseWeight) {
        ModelName = modelName;
        BaseWeight = baseWeight;
    }

    public virtual double FuelOverDistance(double km) {
        return 0d;
    }

    public virtual double FuelOverDistance(params GpsCoordinates[] coords) {
        return 0d;
    }
}