namespace FlySimulatorAPI.Models.Plane.Types;

public class GliderPlane(string modelName, double baseWeight)
    : Plane(modelName, baseWeight) {
    
    public override PlaneType Type => PlaneType.Glider;
}