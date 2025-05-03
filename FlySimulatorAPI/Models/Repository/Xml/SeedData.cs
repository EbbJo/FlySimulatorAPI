using FlySimulatorAPI.Common;
using FlySimulatorAPI.Models.Employee;
using FlySimulatorAPI.Models.Engine;
using FlySimulatorAPI.Models.Plane.Types;

namespace FlySimulatorAPI.Models.Repository.Xml;

public static class SeedData {
    public static void EnsurePopulated() {
        if (!Directory.Exists("Files")) {
            try {
                Directory.CreateDirectory("Files");
            }
            catch (Exception ex) {
                Console.WriteLine("Unable to create Files directory: "+ex.Message);
                return;
            }
        }
        
        if (!File.Exists(PlaneXmlRepository.XmlPath)) {
            var list = GeneratePlanes();
            try {
                new XmlMediator<XmlPlaneList>().ProduceXml(list, PlaneXmlRepository.XmlPath);
            }
            catch (Exception ex) {
                Console.WriteLine("Unable to generate planes list: "+ex.Message);
            }
        }
        
        if (!File.Exists(AirportXmlRepository.XmlPath)) {
            var list = GenerateAirports();
            try {
                new XmlMediator<XmlAirportList>().ProduceXml(list, AirportXmlRepository.XmlPath);
            }
            catch (Exception ex) {
                Console.WriteLine("Unable to generate airports list: "+ex.Message);
            }
        }
        
        if (!File.Exists(EmployeeXmlRepository.XmlPath)) {
            var list = GenerateEmployees();
            try {
                new XmlMediator<XmlEmployeeList>().ProduceXml(list, EmployeeXmlRepository.XmlPath);
            }
            catch (Exception ex) {
                Console.WriteLine("Unable to generate employee list: "+ex.Message);
            }
        }
    }

    private static XmlPlaneList GeneratePlanes() {
        return new XmlPlaneList {
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

    private static XmlAirportList GenerateAirports() {
        return new XmlAirportList {
            Airports = [
                new Airport.Airport {
                    Name = "Hartsfield–Jackson Atlanta International Airport",
                    Position = new GpsCoordinates(33.6407, -84.4277)
                },
                new Airport.Airport {
                    Name = "Beijing Capital International Airport",
                    Position = new GpsCoordinates(40.0799, 116.6031)
                },
                new Airport.Airport {
                    Name = "Dubai International Airport",
                    Position = new GpsCoordinates(25.2532, 55.3657)
                },
                new Airport.Airport {
                    Name = "Los Angeles International Airport",
                    Position = new GpsCoordinates(33.9416, -118.4085)
                },
                new Airport.Airport {
                    Name = "Heathrow Airport",
                    Position = new GpsCoordinates(51.4700, -0.4543)
                },
                new Airport.Airport {
                    Name = "Tokyo Haneda Airport",
                    Position = new GpsCoordinates(35.5494, 139.7798)
                }
            ]
        };
    }

    private static XmlEmployeeList GenerateEmployees() {
        return new XmlEmployeeList {
            Employees = [
                new Employee.Employee {
                    Name = "Alice Johnson",
                    Type = EmployeeType.Pilot,
                    Salary = 120_000m
                },
                new Employee.Employee {
                    Name = "Michael Lee",
                    Type = EmployeeType.GroundCrew,
                    Salary = 45_000m
                },
                new Employee.Employee {
                    Name = "Sandra Kim",
                    Type = EmployeeType.FlightAttendant,
                    Salary = 52_000m
                },
                new Employee.Employee {
                    Name = "David Garcia",
                    Type = EmployeeType.Mechanic,
                    Salary = 65_000m
                },
                new Employee.Employee {
                    Name = "Rachel Patel",
                    Type = EmployeeType.CustomerService,
                    Salary = 38_000m
                },
                new Employee.Employee {
                    Name = "James O'Connor",
                    Type = EmployeeType.CargoHandler,
                    Salary = 42_000m
                },
                new Employee.Employee {
                    Name = "Emily Chen",
                    Type = EmployeeType.Navigator,
                    Salary = 78_000m
                },
                new Employee.Employee {
                    Name = "Robert Martinez",
                    Type = EmployeeType.Security,
                    Salary = 40_000m
                },
                new Employee.Employee {
                    Name = "Natalie Brooks",
                    Type = EmployeeType.Dispatcher,
                    Salary = 55_000m
                },
                new Employee.Employee {
                    Name = "Tom Nguyen",
                    Type = EmployeeType.MaintenanceSupervisor,
                    Salary = 70_000m
                }
            ]
        };
    }
}