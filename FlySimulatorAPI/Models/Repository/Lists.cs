using FlySimulatorAPI.Models.Plane.Types;

namespace FlySimulatorAPI.Models.Repository;

public class PlaneList {
    public AirLinerPlane[] AirLinerPlanes { get; set; } = [];
    public AmphibiousPlane[] AmphibiousPlanes { get; set; } = [];
    public GliderPlane[] GliderPlanes { get; set; } = [];
    public MilitaryPlane[] MilitaryPlanes { get; set; } = [];
}

public class AirportList {
    public Airport.Airport[] Airports { get; set; } = [];
}

public class EmployeeList {
    public Employee.Employee[] Employees { get; set; } = [];
}