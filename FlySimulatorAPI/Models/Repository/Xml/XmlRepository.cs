namespace FlySimulatorAPI.Models.Repository.Xml;

/// <summary>
/// Repository backed by an XML file.
/// </summary>
/// <typeparam name="T">Type of object to store in repository.</typeparam>
public abstract class XmlRepository<T> : IRepository<T> {
    /// <summary>
    /// Path to store XML file at.
    /// </summary>
    protected readonly string _xmlPath;
    
    /// <summary>
    /// The current list of objects fetched from the XML file.
    /// Should be updated with the <see cref="UpdateList"/> method before using.
    /// </summary>
    protected IXmlObjectList<T>? XmlList = null;
    
    protected XmlRepository(string xmlPath) {
        _xmlPath = xmlPath;
    }

    public abstract void Add(T obj);

    public abstract T? GetById(Guid id);
    
    public abstract List<T> GetAll();

    public abstract void Delete(Guid id);
    
    public abstract void Update(Guid id, T obj);

    public abstract void SaveChanges();

    /// <summary>
    /// Get a list of objects in the repository.
    /// </summary>
    /// <returns>The list.</returns>
    protected List<T> GetList() => XmlList is null ? [] : XmlList.GetList();

    /// <summary>
    /// Set the contents of the repository to the given list.
    /// </summary>
    /// <param name="list">The list that will be the new contents of the repository.</param>
    protected void SetList(List<T> list) => XmlList?.SetList(list);

    /// <summary>
    /// Update the <see cref="XmlList"/> member to the latest version found in the xml file.
    /// </summary>
    protected abstract void UpdateList();

    /// <summary>
    /// Check that the XML file exists.
    /// </summary>
    /// <returns>True if the XML file exists.</returns>
    public bool FileExists() {
        return File.Exists(_xmlPath);
    }
}