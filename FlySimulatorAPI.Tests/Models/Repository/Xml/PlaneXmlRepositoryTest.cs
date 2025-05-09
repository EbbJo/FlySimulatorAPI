﻿using FlySimulatorAPI.Models.Engine;
using FlySimulatorAPI.Models.Plane.Types;
using FlySimulatorAPI.Models.Repository.Xml;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace FlySimulatorAPI.Tests.Models.Repository.Xml;

[TestSubject(typeof(PlaneXmlRepository))]
public class PlaneXmlRepositoryTest {

    /// <summary>
    /// Test that the plane repository can maintain the number of planes when
    /// given a list by an XML mediator.
    /// </summary>
    [Fact]
    public void GetPlanes_TwoPlanes_MaintainsCount() {
        //Arrange
        var mock = new Mock<IXmlMediator<XmlPlaneList>>();

        //Setup mock mediator with two planes of different types
        mock.Setup(mediator => mediator.ReadXml(PlaneXmlRepository.XmlPath))
            .Returns(new XmlPlaneList {
                AirLinerPlanes = [
                    new AirLinerPlane(
                        "Boeing 737-800",
                        41413d,
                        876d,
                        new EngineParameters {
                            FuelCapacity = 26020d,
                            FuelEfficiency = 0.08d
                        },
                        189,
                        13608,
                        20000d
                    )
                ],
                AmphibiousPlanes = [
                    new AmphibiousPlane(
                        "Canadair CL-415",
                        12500d,
                        359d,
                        new EngineParameters {
                            FuelCapacity = 7200d,
                            FuelEfficiency = 0.07d
                        }
                    )
                ]
            });

        mock.Setup(mediator => mediator.ProduceXml(It.IsAny<XmlPlaneList>(), PlaneXmlRepository.XmlPath));
        
        var repo = new PlaneXmlRepository(mock.Object);

        //Act
        
        //Use the "GetAll" method to produce a list it will gather from the XmlMediator.
        var list = repo.GetAll();

        //Assert
        
        //Make sure no information was lost/added from simply constructing the list.
        Assert.Equal(2, list.Count);
    }
    
    /// <summary>
    /// Test that the "Add" method on the plane repository behaves as expected,
    /// and the input list of length 2 is increased to 3.
    /// </summary>
    [Fact]
    public void GetPlanes_TwoPlanes_IsThreeAfterAdd() {
        //Arrange
        var mock = new Mock<IXmlMediator<XmlPlaneList>>();

        //Setup mediator mock with two planes of different types
        mock.Setup(mediator => mediator.ReadXml(PlaneXmlRepository.XmlPath))
            .Returns(new XmlPlaneList {
                AirLinerPlanes = [
                    new AirLinerPlane(
                        "Boeing 737-800",
                        41413d,
                        876d,
                        new EngineParameters {
                            FuelCapacity = 26020d,
                            FuelEfficiency = 0.08d
                        },
                        189,
                        13608,
                        20000d
                    )
                ],
                AmphibiousPlanes = [
                    new AmphibiousPlane(
                        "Canadair CL-415",
                        12500d,
                        359d,
                        new EngineParameters {
                            FuelCapacity = 7200d,
                            FuelEfficiency = 0.07d
                        }
                    )
                ]
            });

        mock.Setup(mediator => mediator.ProduceXml(It.IsAny<XmlPlaneList>(), PlaneXmlRepository.XmlPath));
        
        var repo = new PlaneXmlRepository(mock.Object);

        //Act
        
        //Add a new plane to the list, make it a different type to the others for good measure.
        repo.Add(new MilitaryPlane(
            "SomeModel",
            12500d,
            359d,
            new EngineParameters {
                FuelCapacity = 26020d,
                FuelEfficiency = 1
            },
            2,
            1000d,
            1000d)
        );

        //Assert
        
        //Make sure the length is now 3
        Assert.Equal(3, repo.GetAll().Count);
    }
}