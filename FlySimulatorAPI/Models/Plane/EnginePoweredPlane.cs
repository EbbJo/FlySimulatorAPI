using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane;

public abstract class EnginePoweredPlane : Plane {

    [Required]
    public EngineParameters EngineParams { get; set; } = new();

    protected EnginePoweredPlane() { }
    
    protected EnginePoweredPlane(string modelName, double baseWeight, double topSpeed, EngineParameters engineParams)
        : base(modelName, baseWeight, topSpeed) {
        EngineParams = engineParams;
    }
    
    public override double FuelOverDistance(double km) {
        return EngineParams.FuelEfficiency * km;
    }

    public override double FuelOverDistance(params GpsCoordinates[] coords) {
        return EngineParams.FuelEfficiency * GpsCoordinates.ChainDistKm(coords);
    }
}