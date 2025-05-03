
namespace FlySimulatorAPI.Models.Repository.Xml;

public class PlaneXmlRepository : XmlRepository<Plane.Plane> {
    public const string XmlPath = "Files/planes.xml";
    
    private readonly IXmlMediator<XmlPlaneList> _listMediator;

    public PlaneXmlRepository(IXmlMediator<XmlPlaneList> listMediator)
        : base(XmlPath) {
        _listMediator = listMediator;
    }
    
    public override void Add(Plane.Plane plane) {
        UpdateList();

        var list = GetList();
        
        list.Add(plane);
        
        SetList(list);
    }

    public override Plane.Plane? GetById(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        return list.FirstOrDefault(obj => obj.Id == id);
    }

    public override List<Plane.Plane> GetAll() {
        UpdateList();

        return GetList();
    }

    public override void SaveChanges() {
        if (XmlList is null) return;
        
        _listMediator.ProduceXml((XmlPlaneList)XmlList, XmlPath);
    }

    public override void Delete(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        list.RemoveAll(plane => plane.Id == id);
    }

    protected override void UpdateList() {
        XmlList = _listMediator.ReadXml(_xmlPath);
    }
}