using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane;

public abstract class EnginePoweredPlane(
    string modelName, double baseWeight, EngineParameters engineParams)
    : Plane(modelName, baseWeight) {

    public EngineParameters EngineParams { get; private set; } = engineParams;

    public override double FuelOverDistance(double km) {
        return EngineParams.FuelEfficiency * km;
    }

    public override double FuelOverDistance(params GpsCoordinates[] coords) {
        return EngineParams.FuelEfficiency * GpsCoordinates.ChainDistKm(coords);
    }
}