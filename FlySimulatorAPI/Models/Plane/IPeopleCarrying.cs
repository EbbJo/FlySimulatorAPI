using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Plane;

public interface IPeopleCarrying {
    /// <summary>
    /// Amount of passengers this plane can hold.
    /// </summary>
    [Required]
    public uint PassengerCapacity { get; set; }

    /// <summary>
    /// Amount of weight (kg) added when at full capacity of passengers.
    /// </summary>
    [Required]
    public double FullPassengerCapacityWeightAddition { get; set; }
}