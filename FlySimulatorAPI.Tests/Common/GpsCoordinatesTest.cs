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

    [Fact]
    public void ChainDistKm_ThreePoints_ExpectedValue() {
        //Arrange

        GpsCoordinates p1 = new(55.74693907446503, 9.148272574884944);
        GpsCoordinates p2 = new(55.6296135419299, 12.64902623452635);
        GpsCoordinates p3 = new(54.83609326133094, 9.378259886951168);

        //Act
        
        double dist = GpsCoordinates.ChainDistKm(p1, p2, p3);
        
        //Find distances between points
        
        //Point 1 and 2
        double expected = p1.DistKm(p2) + p2.DistKm(p3);

        //Assert
        
        Assert.Equal(expected, dist);
    }
}