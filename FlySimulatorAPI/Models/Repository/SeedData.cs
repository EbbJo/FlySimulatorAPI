using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FlySimulatorAPI.Models.Engine;
using FlySimulatorAPI.Models.Plane.Types;

namespace FlySimulatorAPI.Models.Repository;

public static class SeedData {
    public static void EnsurePopulated() {
        if (!File.Exists("Files/planes.xml")) {
            var list = GeneratePlanes();
            try {
                ProduceXml(list, "Files/planes.xml");
            }
            catch (Exception ex) {
                throw;  //Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ProduceXml(object obj, string path) {
        var xmlSerializer = new XmlSerializer(obj.GetType());

        using var writer = new StringWriter();
        
        xmlSerializer.Serialize(writer, obj);
        File.WriteAllText(path, writer.ToString()); //Possible exception caught by caller
    }

    private static PlaneList GeneratePlanes() {
        return new PlaneList {
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
                ),
                new AirLinerPlane(
                    "Airbus A320neo",
                    42600d,
                    new EngineParameters {
                        FuelCapacity = 24210d,
                        FuelEfficiency = 0.09d
                    },
                    180,
                    12960,
                    19500d
                ),
                new AirLinerPlane(
                    "Embraer E190",
                    28900d,
                    new EngineParameters {
                        FuelCapacity = 13000d,
                        FuelEfficiency = 0.1d
                    },
                    100,
                    7200,
                    13000d
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
                ),
                new AmphibiousPlane(
                    "Grumman G-21 Goose",
                    3400d,
                    new EngineParameters {
                        FuelCapacity = 1800d,
                        FuelEfficiency = 0.09d
                    }
                ),
                new AmphibiousPlane(
                    "ICON A5",
                    686d,
                    new EngineParameters {
                        FuelCapacity = 87d,
                        FuelEfficiency = 0.2d
                    }
                )
            ],
            GliderPlanes = [
                new GliderPlane(
                    "Schleicher ASW 27",
                    290d
                ),
                new GliderPlane(
                    "Schempp-Hirth Duo Discus",
                    410d
                ),
                new GliderPlane(
                    "DG Flugzeugbau DG-1001",
                    510d
                )
            ],
            MilitaryPlanes = [
                new MilitaryPlane(
                    "F-16 Fighting Falcon",
                    8840d,
                    new EngineParameters {
                        FuelCapacity = 3100d,
                        FuelEfficiency = 0.04d
                    },
                    1,
                    100,
                    1000d
                ),
                new MilitaryPlane(
                    "C-130 Hercules",
                    34400d,
                    new EngineParameters {
                        FuelCapacity = 19000d,
                        FuelEfficiency = 0.06d
                    },
                    92,
                    6624,
                    20000d
                ),
                new MilitaryPlane(
                    "B-2 Spirit",
                    71700d,
                    new EngineParameters {
                        FuelCapacity = 75000d,
                        FuelEfficiency = 0.03d
                    },
                    2,
                    200,
                    18000d
                )
            ]
        };
    }
}