using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Plane;

public abstract class Plane(string modelName, double baseWeight) {
    [Key]
    public int Id { get; set; }
    
    public virtual PlaneType Type => PlaneType.None;
    
    /// <summary>
    /// The weight of the plane with no cargo/passengers.
    /// </summary>
    public double BaseWeight { get; set; } = baseWeight;

    public string ModelName { get; set; } = modelName;

    public virtual double FuelOverDistance(double km) {
        return 0d;
    }

    public virtual double FuelOverDistance(ICollection<GpsCoordinates> coords) {
        return 0d;
    }
}