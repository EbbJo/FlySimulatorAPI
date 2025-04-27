namespace FlySimulatorAPI;

/// <summary>
/// Extension for the <see cref="WebApplication"/> class to add
/// the API endpoints for this API.
/// </summary>
public static class Endpoints {
    public static void MapEndpoints(this WebApplication app) {
        var group = app.MapGroup("/test");
    }
}