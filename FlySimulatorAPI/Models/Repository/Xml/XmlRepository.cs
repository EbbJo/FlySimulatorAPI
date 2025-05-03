namespace FlySimulatorAPI.Models.Repository.Xml;

/// <summary>
/// Repository backed by an xml file.
/// </summary>
/// <typeparam name="T">Type of object to store in repository.</typeparam>
public abstract class XmlRepository<T> : IRepository<T> {
    protected readonly string _xmlPath;
    
    protected IXmlObjectList<T>? XmlList = null;
    
    protected XmlRepository(string xmlPath) {
        _xmlPath = xmlPath;
    }

    public abstract void Add(T obj);

    public abstract T? GetById(Guid id);
    
    public abstract List<T> GetAll();

    public abstract void SaveChanges();

    public abstract void Delete(Guid id);

    /// <summary>
    /// Get a list of objects in the repository.
    /// </summary>
    /// <returns>The list.</returns>
    protected List<T> GetList() {
        return XmlList is null ? [] : XmlList.GetList();
    }

    /// <summary>
    /// Set the contents of the repository to the given list.
    /// </summary>
    /// <param name="list">The list that will be the new contents of the repository.</param>
    protected void SetList(List<T> list) {
        XmlList?.SetList(list);
    }

    /// <summary>
    /// Update the <see cref="XmlList"/> member to the latest version found in the xml file.
    /// </summary>
    protected abstract void UpdateList();

    public bool FileExists() {
        return File.Exists(_xmlPath);
    }
}