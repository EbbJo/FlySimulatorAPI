using FlySimulatorAPI.Models.Engine;

namespace FlySimulatorAPI.Models.Plane.Types;

[Serializable]
public class AmphibiousPlane : EnginePoweredPlane {

    public AmphibiousPlane() { }

    public AmphibiousPlane(string modelName, double baseWeight, double topSpeed, EngineParameters engineParams)
        : base(modelName, baseWeight, topSpeed, engineParams) { }
    
    public override PlaneType Type => PlaneType.Amphibious;
}