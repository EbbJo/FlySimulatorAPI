namespace FlySimulatorAPI.Models.Plane.Types;

[Serializable]
public class GliderPlane : Plane {
    
    public GliderPlane() { }
    
    public GliderPlane(string modelName, double baseWeight, double topSpeed)
        : base(modelName, baseWeight, topSpeed) { }
    
    public override PlaneType Type => PlaneType.Glider;
}