namespace FlySimulatorAPI.Models.Repository.Xml;

public interface IXmlMediator<T> where T : class, new() {
    /// <summary>
    /// Write an xml-serialized version of the object to an .xml file.
    /// </summary>
    /// <param name="obj">Object to serialize.</param>
    /// <param name="path">Path to write file to.</param>
    public void ProduceXml(T obj, string path);

    /// <summary>
    /// Read an xml-serialized object from an .xml file.
    /// </summary>
    /// <param name="path">Path to read the file from.</param>
    /// <returns>The deserialized object, or a default instance if the path was not found.</returns>
    public T? ReadXml(string path);
}