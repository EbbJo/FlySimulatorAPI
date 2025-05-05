using System.Xml.Serialization;

namespace FlySimulatorAPI.Models.Repository.Xml;

/// <summary>
/// Implementation of the <see cref="IXmlMediator{T}"/> interface.
/// </summary>
/// <typeparam name="T">Type of object to serialize/deserialize.</typeparam>
public class XmlMediator<T> : IXmlMediator<T> where T : class, new() {
    public void ProduceXml(T obj, string path) {
        var xmlSerializer = new XmlSerializer(obj.GetType());

        using var writer = new StringWriter();

        try {
            xmlSerializer.Serialize(writer, obj);
            File.WriteAllText(path, writer.ToString());
        }
        catch (Exception ex) {
            Console.WriteLine("XmlMediator: Could not write XML object: "+ex.Message);
        }
    }
    
    public T? ReadXml(string path) {
        var xmlSerializer = new XmlSerializer(typeof(T));

        try {
            string xml = File.ReadAllText(path);
            return xmlSerializer.Deserialize(new StringReader(xml)) as T;
        }
        catch (Exception ex) {
            Console.WriteLine("XmlMediator: Could not read XML object: "+ex.Message);
            return new T();
        }
    }
}