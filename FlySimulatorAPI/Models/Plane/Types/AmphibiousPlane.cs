using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

public class AmphibiousPlane(string modelName, double baseWeight, EngineParameters engineParams)
    : EnginePoweredPlane(modelName, baseWeight, engineParams) {

    public override PlaneType Type => PlaneType.Amphibious;
}