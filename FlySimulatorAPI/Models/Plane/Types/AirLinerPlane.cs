using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

public class AirLinerPlane(string modelName, double baseWeight, EngineParameters engineParams)
    : EnginePoweredPlane(modelName, baseWeight, engineParams), IPeopleCarrying, ICargoCarrying {

    public override PlaneType Type => PlaneType.Airliner;
    
    public uint PassengerCapacity { get; set; }

    public double FullPassengerCapacityWeightAddition { get; set; }

    public double CargoWeightCapacity { get; set; }

    public AirLinerPlane(string modelName, double baseWeight, EngineParameters engineParams, uint passengerCapacity,
        double fullPassengerCapacityWeightAddition, double cargoWeightCapacity)
        : this(modelName, baseWeight, engineParams) {
        PassengerCapacity = passengerCapacity;
        FullPassengerCapacityWeightAddition = fullPassengerCapacityWeightAddition;
        CargoWeightCapacity = cargoWeightCapacity;
    }
}