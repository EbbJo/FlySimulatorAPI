namespace FlySimulatorAPI.Models.Plane;

public interface IPeopleCarrying {
    public uint PassengerCapacity { get; set; }

    /// <summary>
    /// Amount of weight (kg) added when at full capacity of passengers.
    /// </summary>
    public double FullPassengerCapacityWeightAddition { get; set; }
}