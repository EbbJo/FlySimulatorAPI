namespace FlySimulatorAPI.Models.Repository.Xml;

public abstract class XmlRepository<TObject> : IRepository<TObject> {
    protected string _xmlPath;
    
    protected IXmlObjectList<TObject>? _xmlList = null;
    
    protected XmlRepository(string xmlPath) {
        _xmlPath = xmlPath;
    }

    public abstract void Add(TObject obj);

    public abstract List<TObject> GetAll();

    public abstract void SaveChanges();

    public abstract void Delete(TObject obj);

    protected List<TObject> GetList() {
        return _xmlList is null ? [] : _xmlList.GetList();
    }

    protected void SetList(List<TObject> list) {
        _xmlList?.SetList(list);
    }

    protected abstract void UpdateList();

    public bool FileExists() {
        return File.Exists(_xmlPath);
    }
}