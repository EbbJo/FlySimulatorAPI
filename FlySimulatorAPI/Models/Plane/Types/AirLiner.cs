namespace FlySimulatorAPI.Models.Plane.Types;

public class AirLiner : Plane, IEnginePowered, IPassengerCarrying {
    public double FuelCapacity { get; set; }
    
    public double FuelEfficiency { get; set; }
    
    public uint PassengerCapacity { get; set; }
    
    public double FullPassengerCapacityWeightAddition { get; set; }
}