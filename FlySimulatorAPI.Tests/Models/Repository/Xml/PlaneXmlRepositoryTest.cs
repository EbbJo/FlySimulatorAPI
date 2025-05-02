using FlySimulatorAPI.Models.Engine;
using FlySimulatorAPI.Models.Plane.Types;
using FlySimulatorAPI.Models.Repository.Xml;
using JetBrains.Annotations;
using Moq;
using Xunit;

namespace FlySimulatorAPI.Tests.Models.Repository.Xml;

[TestSubject(typeof(PlaneXmlRepository))]
public class PlaneXmlRepositoryTest {

    [Fact]
    public void GetPlanes_TwoPlanes_MaintainsCount() {
        //Arrange
        var mock = new Mock<IXmlMediator<XmlPlaneList>>();

        //Setup mock with two planes of different types
        mock.Setup(mediator => mediator.ReadXml(PlaneXmlRepository.XmlPath))
            .Returns(new XmlPlaneList {
                AirLinerPlanes = [
                    new AirLinerPlane(
                        "Boeing 737-800",
                        41413d,
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
        
        var list = repo.GetAll();

        //Assert
        
        Assert.Equal(list.Count, 2);
    }
}