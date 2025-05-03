
namespace FlySimulatorAPI.Models.Repository.Xml;

public class EmployeeXmlRepository : XmlRepository<Employee.Employee> {
    public const string XmlPath = "Files/employees.xml";
    
    private readonly IXmlMediator<XmlEmployeeList> _listMediator;

    public EmployeeXmlRepository(IXmlMediator<XmlEmployeeList> listMediator)
        : base(XmlPath) {
        _listMediator = listMediator;
    }
    
    public override void Add(Employee.Employee employee) {
        UpdateList();

        var list = GetList();
        
        list.Add(employee);
        
        SetList(list);
    }

    public override Employee.Employee? GetById(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        return list.FirstOrDefault(obj => obj.Id == id);
    }

    public override List<Employee.Employee> GetAll() {
        UpdateList();

        return GetList();
    }

    public override void SaveChanges() {
        if (XmlList is null) return;
        
        _listMediator.ProduceXml((XmlEmployeeList)XmlList, XmlPath);
    }

    public override void Delete(Guid id) {
        UpdateList();
        
        var list = GetList();
        
        list.RemoveAll(employee => employee.Id == id);
    }

    protected override void UpdateList() {
        XmlList = _listMediator.ReadXml(_xmlPath);
    }
}