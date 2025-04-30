using System;
using FlySimulatorAPI.Common;
using JetBrains.Annotations;
using Xunit;

namespace FlySimulatorAPI.Tests.Common;

[TestSubject(typeof(GpsCoordinates))]
public class GpsCoordinatesTest {

    [Fact]
    public void DistKm_TwoPoints_ExpectedValue() {
        //Arrange

        GpsCoordinates p1 = new(55.74693907446503, 9.148272574884944);
        GpsCoordinates p2 = new(55.6296135419299, 12.64902623452635);

        //Act
        
        double dist = p1.DistKm(p2);

        //Formula for degree distance:
        //d=acos(sin(lat1)*sin(lat2)+cos(lat1)*cos(lat2)*cos(lon1-lon2))
        
        double expected = Math.Acos(
                Math.Sin(p1.LatitudeRad)*
                Math.Sin(p2.LatitudeRad)
                +
                Math.Cos(p1.LatitudeRad)*
                Math.Cos(p2.LatitudeRad)*
                Math.Cos(p1.LongitudeRad - p2.LongitudeRad)
            );

        //Convert to km
        expected *= GpsCoordinates.EarthRadiusKm;

        //Assert
        
        Assert.Equal(expected, dist);
    }
}