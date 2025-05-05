using System.ComponentModel.DataAnnotations;
using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane;

/// <summary>
/// Represents a type of <see cref="Plane"/> that uses an engine for propulsion.
/// </summary>
public abstract class EnginePoweredPlane : Plane {

    /// <summary>
    /// Parameters for the engine.
    /// </summary>
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

    public override string ToString() {
        return base.ToString() + $", Engine Parameters: [{EngineParams}]";
    }
}