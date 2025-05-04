using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

[Serializable]
public class AirLinerPlane : EnginePoweredPlane, IPeopleCarrying, ICargoCarrying {

    public override PlaneType Type => PlaneType.Airliner;

    [Required] public uint PassengerCapacity { get; set; } = 0;

    [Required] public double FullPassengerCapacityWeightAddition { get; set; } = 0d;

    [Required] public double CargoWeightCapacity { get; set; } = 0d;

    public AirLinerPlane() { }
    
    public AirLinerPlane(string modelName, double baseWeight, double topSpeed, EngineParameters engineParams)
     : base(modelName, baseWeight, topSpeed, engineParams) { }

    public AirLinerPlane(string modelName, double baseWeight, double topSpeed, EngineParameters engineParams, uint passengerCapacity,
        double fullPassengerCapacityWeightAddition, double cargoWeightCapacity)
        : this(modelName, baseWeight, topSpeed, engineParams) {
        PassengerCapacity = passengerCapacity;
        FullPassengerCapacityWeightAddition = fullPassengerCapacityWeightAddition;
        CargoWeightCapacity = cargoWeightCapacity;
    }
}