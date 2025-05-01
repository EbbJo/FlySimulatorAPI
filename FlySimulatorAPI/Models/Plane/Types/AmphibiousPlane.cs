using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

public class AmphibiousPlane : EnginePoweredPlane {

    public AmphibiousPlane() { }

    public AmphibiousPlane(string modelName, double baseWeight, EngineParameters engineParams)
        : base(modelName, baseWeight, engineParams) { }
    
    public override PlaneType Type => PlaneType.Amphibious;
}