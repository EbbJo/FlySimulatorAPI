using FlySimulatorAPI.Models.Plane.Types;

namespace FlySimulatorAPI.Models.Repository.Xml;

/// <summary>
/// Represents a list of objects to be stored in an XML file.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IXmlObjectList<T> {
    /// <summary>
    /// Get the total number of objects.
    /// </summary>
    public int Length { get; }

    /// <summary>
    /// Get a list of all objects.
    /// </summary>
    /// <returns>The list.</returns>
    public List<T> GetList();
    
    /// <summary>
    /// Set the objects to the contents of the given list.
    /// </summary>
    /// <param name="list">List to get objects from.</param>
    public void SetList(List<T> list);
}

[Serializable]
public class XmlPlaneList : IXmlObjectList<Plane.Plane> {
    public int Length =>
        AirLinerPlanes.Length+
        AmphibiousPlanes.Length+
        GliderPlanes.Length+
        MilitaryPlanes.Length;

    public AirLinerPlane[] AirLinerPlanes { get; set; } = [];
    public AmphibiousPlane[] AmphibiousPlanes { get; set; } = [];
    public GliderPlane[] GliderPlanes { get; set; } = [];
    public MilitaryPlane[] MilitaryPlanes { get; set; } = [];

    public List<Plane.Plane> GetList() {
        var list = new List<Plane.Plane>(Length);

        list.AddRange(AirLinerPlanes);
        list.AddRange(AmphibiousPlanes);
        list.AddRange(GliderPlanes);
        list.AddRange(MilitaryPlanes);

        return list;
    }

    public void SetList(List<Plane.Plane> list) {
        AirLinerPlanes   = (list.Where(p => p is AirLinerPlane  ).ToArray() as AirLinerPlane[]  )!;
        AmphibiousPlanes = (list.Where(p => p is AmphibiousPlane).ToArray() as AmphibiousPlane[])!;
        GliderPlanes     = (list.Where(p => p is GliderPlane    ).ToArray() as GliderPlane[]    )!;
        MilitaryPlanes   = (list.Where(p => p is MilitaryPlane  ).ToArray() as MilitaryPlane[]  )!;
    }
}

[Serializable]
public class XmlAirportList : IXmlObjectList<Airport.Airport> {
    public int Length => Airports.Length;
    public List<Airport.Airport> GetList() => Airports.ToList();

    public void SetList(List<Airport.Airport> list) {
        Airports = list.ToArray();
    }

    public Airport.Airport[] Airports { get; set; } = [];
}

[Serializable]
public class XmlEmployeeList : IXmlObjectList<Employee.Employee> {
    public int Length => Employees.Length;
    
    public List<Employee.Employee> GetList() => Employees.ToList();

    public void SetList(List<Employee.Employee> list) {
        Employees = list.ToArray();
    }

    public Employee.Employee[] Employees { get; set; } = [];
}