using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;

namespace FlySimulatorAPI.Models.Airport;

[Serializable]
public class Airport {
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public GpsCoordinates Position { get; set; } = new();
    
    public Airport() {
        Id = Guid.NewGuid();
    }

    public override string ToString() {
        return $"Airport {Id}: Name: {Name}, Position: [{Position}]";
    }
}