using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Plane;

/// <summary>
/// Base class for all plane types.
/// </summary>
public abstract class Plane {
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// The type of this plane.
    /// </summary>
    public virtual PlaneType Type => PlaneType.None;

    /// <summary>
    /// The weight (kg) of the plane with no cargo/passengers.
    /// </summary>
    [Required]
    public double BaseWeight { get; set; } = 0d;
    
    /// <summary>
    /// Name of this model of plane.
    /// </summary>
    [Required]
    public string ModelName { get; set; } = string.Empty;
    
    /// <summary>
    /// Top speed (kilometers per hour).
    /// </summary>
    [Required]
    public double TopSpeed { get; set; } = 0d;

    /// <summary>
    /// Instantiates the plane and gives it a new unique ID.
    /// </summary>
    protected Plane() {
        Id = Guid.NewGuid();
    }

    protected Plane(string modelName, double baseWeight, double topSpeed) : this() {
        ModelName = modelName;
        BaseWeight = baseWeight;
        TopSpeed = topSpeed;
    }

    /// <summary>
    /// Get the amount of fuel (liters) used over a given distance (km).
    /// </summary>
    /// <param name="km">Distance in kilometers.</param>
    /// <returns>Amount of fuel used in liters.</returns>
    public virtual double FuelOverDistance(double km) {
        return 0d;
    }

    /// <summary>
    /// Get the amount of fuel (liters) used over the summed-up distance between
    /// a chain of coordinates.
    /// </summary>
    /// <param name="coords">Coordinates the flight will be chained through.</param>
    /// <returns>Amount of fuel used in liters.</returns>
    public virtual double FuelOverDistance(params GpsCoordinates[] coords) {
        return 0d;
    }

    public override string ToString() {
        return $"Plane {Id}: Type: {Type}, Base Weight: {BaseWeight}kg, Top Speed: {TopSpeed}km/h";
    }
}