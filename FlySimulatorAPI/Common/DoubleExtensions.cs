namespace FlySimulatorAPI.Common;

public static class DoubleExtensions {
    public static double DegreesToRadians(this double degrees) {
        return (degrees * Math.PI) / 180d;
    }

    public static double RadiansToDegrees(this double radians) {
        return radians * (180d / Math.PI);
    }
}