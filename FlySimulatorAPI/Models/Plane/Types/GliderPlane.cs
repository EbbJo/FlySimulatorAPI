namespace FlySimulatorAPI.Models.Plane.Types;

public class GliderPlane : Plane {
    
    public GliderPlane() { }
    
    public GliderPlane(string modelName, double baseWeight)
        : base(modelName, baseWeight) { }
    
    public override PlaneType Type => PlaneType.Glider;
}