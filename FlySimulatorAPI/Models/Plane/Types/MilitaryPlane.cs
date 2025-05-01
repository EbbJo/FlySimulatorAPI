using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

public class MilitaryPlane : EnginePoweredPlane, IPeopleCarrying, ICargoCarrying {
    
    public override PlaneType Type => PlaneType.Military;
    
    [Required]
    public uint PassengerCapacity { get; set; }

    [Required]
    public double FullPassengerCapacityWeightAddition { get; set; }

    [Required]
    public double CargoWeightCapacity { get; set; }

    public MilitaryPlane() { }
    
    public MilitaryPlane(string modelName, double baseWeight, EngineParameters engineParams)
        : base(modelName, baseWeight, engineParams) { }

    public MilitaryPlane(string modelName, double baseWeight, EngineParameters engineParams, uint passengerCapacity,
        double fullPassengerCapacityWeightAddition, double cargoWeightCapacity)
        : this(modelName, baseWeight, engineParams) {
        PassengerCapacity = passengerCapacity;
        FullPassengerCapacityWeightAddition = fullPassengerCapacityWeightAddition;
        CargoWeightCapacity = cargoWeightCapacity;
    }
}