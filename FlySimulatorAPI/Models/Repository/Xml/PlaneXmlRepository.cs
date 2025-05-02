using FlySimulatorAPI.Models.Plane.Types;

namespace FlySimulatorAPI.Models.Repository.Xml;

public class PlaneXmlRepository : XmlRepository<Plane.Plane> {
    public const string XmlPath = "Files/planes.xml";
    
    private readonly IXmlMediator<XmlPlaneList> _listMediator;

    public PlaneXmlRepository(IXmlMediator<XmlPlaneList> listMediator)
        : base(XmlPath) {
        _listMediator = listMediator;
    }
    
    public override void Add(Plane.Plane plane) {
        Update();

        var list = GetList();
        
        list.Add(plane);
        
        SetList(list);
    }

    public override List<Plane.Plane> GetAll() {
        Update();

        return GetList();
    }

    public override void SaveChanges() {
        if (_xmlList is null) return;
        
        _listMediator.ProduceXml((XmlPlaneList)_xmlList, XmlPath);
    }

    public override void Delete(Plane.Plane obj) {
        Update();
        
        var list = GetList();
        
        list.RemoveAll(plane => plane.Id == obj.Id);
    }

    protected override void UpdateList() {
        _xmlList = _listMediator.ReadXml(_xmlPath);
    }

    //Get the latest version of the xml document with the list.
    private void Update() {
        _xmlList = _listMediator.ReadXml(_xmlPath);
    }
}