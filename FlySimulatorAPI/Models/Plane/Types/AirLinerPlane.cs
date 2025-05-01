using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

public class AirLinerPlane : EnginePoweredPlane, IPeopleCarrying, ICargoCarrying {

    public override PlaneType Type => PlaneType.Airliner;

    [Required] public uint PassengerCapacity { get; set; } = 0;

    [Required] public double FullPassengerCapacityWeightAddition { get; set; } = 0d;

    [Required] public double CargoWeightCapacity { get; set; } = 0d;

    public AirLinerPlane() { }
    
    public AirLinerPlane(string modelName, double baseWeight, EngineParameters engineParams)
     : base(modelName, baseWeight, engineParams) { }

    public AirLinerPlane(string modelName, double baseWeight, EngineParameters engineParams, uint passengerCapacity,
        double fullPassengerCapacityWeightAddition, double cargoWeightCapacity)
        : this(modelName, baseWeight, engineParams) {
        PassengerCapacity = passengerCapacity;
        FullPassengerCapacityWeightAddition = fullPassengerCapacityWeightAddition;
        CargoWeightCapacity = cargoWeightCapacity;
    }
}