using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Airport;

[Serializable]
public class Airport {
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Name of the airport.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Geological position of the airport.
    /// </summary>
    [Required]
    public GpsCoordinates Position { get; set; } = new();
    
    /// <summary>
    /// Instantiates the airport and gives it a new unique ID.
    /// </summary>
    public Airport() {
        Id = Guid.NewGuid();
    }

    public override string ToString() {
        return $"Airport {Id}: Name: {Name}, Position: [{Position}]";
    }
}