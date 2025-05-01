using FlySimulatorAPI.Models.Plane;

namespace FlySimulatorAPI.Models.Repository;

public interface IPlaneRepository {
    void AddPlane(Plane.Plane plane);
    
    IAsyncEnumerable<Plane.Plane> GetPlanesAsync();
    
    Task SaveChangesAsync();
}