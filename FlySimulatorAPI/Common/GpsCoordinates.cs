namespace FlySimulatorAPI.Common;

/// <summary>
/// Represents a point on the earth. Earth's radius is assumed to be 6371km.
/// </summary>
public class GpsCoordinates {
    public const double EarthRadiusKm = 6371d;
    
    /// <summary>
    /// The latitude of the point in radians.
    /// </summary>
    public double LatitudeRad { get; set; }

    /// <summary>
    /// The longitude of the point in radians.
    /// </summary>
    public double LongitudeRad { get; set; }

    /// <summary>
    /// The latitude of the point in degrees.
    /// </summary>
    public double LatitudeDeg {
        get => LatitudeRad.RadiansToDegrees();
        set => LatitudeRad = value.DegreesToRadians();
    }
    
    /// <summary>
    /// The longitude of the point in degrees.
    /// </summary>
    public double LongitudeDeg {
        get => LongitudeRad.RadiansToDegrees();
        set => LongitudeRad = value.DegreesToRadians();
    }

    public GpsCoordinates() {}
    
    public GpsCoordinates(double latitudeDeg, double longitudeDeg) {
        LatitudeDeg = latitudeDeg;
        LongitudeDeg = longitudeDeg;
    }

    /// <summary>
    /// Derived from:
    /// https://edwilliams.org/avform147.htm#Dist
    /// d=acos(sin(lat1)*sin(lat2)+cos(lat1)*cos(lat2)*cos(lon1-lon2))
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public double DistDegrees(GpsCoordinates other) {
        return DistRadians(other).RadiansToDegrees();
    }

    public double DistRadians(GpsCoordinates other) {
        return Math.Acos(
            Math.Sin(LatitudeRad)*
            Math.Sin(other.LatitudeRad)
            +
            Math.Cos(LatitudeRad)*
            Math.Cos(other.LatitudeRad)*
            Math.Cos(LongitudeRad - other.LongitudeRad)
        );
    }

    public double DistKm(GpsCoordinates other) {
        return DistRadians(other) * EarthRadiusKm;
    }

    public static double ChainDistDegrees(params GpsCoordinates[] coords) {
        if (coords.Length < 2) return 0;

        double totalDist = 0;

        for (int i = 0; i < coords.Length-1; i++) {
            totalDist += coords[i].DistDegrees(coords[i + 1]);
        }
        
        return totalDist;
    }

    public static double ChainDistKm(params GpsCoordinates[] coords) {
        if (coords.Length < 2) return 0;

        double totalDist = 0;

        for (int i = 0; i < coords.Length-1; i++) {
            totalDist += coords[i].DistKm(coords[i + 1]);
        }
        
        return totalDist;
    }

    public override string ToString() {
        return $"Lat: {LatitudeDeg}, Lon: {LongitudeDeg}";
    }
}