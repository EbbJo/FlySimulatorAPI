namespace FlySimulatorAPI.Common;

public class GpsCoordinates {
    public const double EarthRadiusKm = 6371d;
    
    private double _latitude;
    private double _longitude;
    
    //Coordinates are exposed as degrees to make calculations easier for
    //outside actors.
    
    public double Latitude {
        get => _latitude.RadiansToDegrees();
        set => _latitude = value.DegreesToRadians();
    }
    
    public double Longitude {
        get => _longitude.RadiansToDegrees();
        set => _longitude = value.DegreesToRadians();
    }

    /// <summary>
    /// Derived from:
    /// https://edwilliams.org/avform147.htm#Dist
    /// d=acos(sin(lat1)*sin(lat2)+cos(lat1)*cos(lat2)*cos(lon1-lon2))
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public double DistDegrees(GpsCoordinates other) {
        return Math.Acos(
            Math.Sin(_latitude) * Math.Sin(other._latitude) +
            Math.Cos(_latitude) * Math.Cos(other._latitude) *
            Math.Cos(_longitude * other._longitude)
        ).RadiansToDegrees();
    }

    public double DistKm(GpsCoordinates other) {
        return DistDegrees(other) * EarthRadiusKm;
    }
}