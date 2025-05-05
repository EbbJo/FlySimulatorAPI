namespace FlySimulatorAPI.Common;

public static class DoubleExtensions {
    /// <summary>
    /// Convert a value in degrees to the equivalent value in radians.
    /// </summary>
    /// <param name="degrees">Value in degrees.</param>
    /// <returns>Value in radians.</returns>
    public static double DegreesToRadians(this double degrees)
        => (degrees * Math.PI) / 180d;

    /// <summary>
    /// Convert a value in radians to the equivalent value in degrees.
    /// </summary>
    /// <param name="radians">Value in radians.</param>
    /// <returns>Value in degrees.</returns>
    public static double RadiansToDegrees(this double radians)
        => radians * (180d / Math.PI);
}