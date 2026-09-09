namespace ViXmlTools;

using System.Xml.Serialization;

public static class XmlUtilities
{
    /// <summary>
    ///  Serializes an DTO to an XML formatted string.
    ///  It also removes the XML namespaces!
    /// </summary>
    public static string Serialize<T>(T obj, string root)
    {
        XmlRootAttribute xmlRoot = new(root);
        XmlSerializer serializer = new(typeof(T), xmlRoot);

        using StringWriter writer = new();

        XmlSerializerNamespaces namespaces = new();
        namespaces.Add(string.Empty, string.Empty);

        serializer.Serialize(writer, obj, namespaces);

        return writer.ToString().Trim();
    }

    /// <summary>
    ///  Async method.
    ///  Serializes an DTO to an XML formatted string.
    ///  It also removes the XML namespaces!
    /// </summary>
    public async static Task<string> SerializeAsync<T>(T obj, string root) 
        => await Task.Run(() => Serialize(obj, root));

    /// <summary>
    ///  Deserializes an XML formatted string into an array of DTOs.
    /// </summary>
    public static T[] Deserialize<T>(string inputXml, string root)
    {
        XmlRootAttribute xmlRoot = new(root);
        XmlSerializer serializer = new(typeof(T[]), xmlRoot);

        using StringReader reader = new(inputXml);

        T[] importedData =
            (T[]?)serializer.Deserialize(reader)
            ?? Array.Empty<T>();

        return importedData;
    }

    /// <summary>
    ///  Async method.
    ///  Deserializes an XML formatted string into an array of DTOs.
    /// </summary>
    public async static Task<T[]> DeserializeAsync<T>(string inputXml, string root) 
        => await Task.Run(() => Deserialize<T>(inputXml, root));

    /// <summary>
    ///  This method is made specificly for SoftUni exercises and its file structure.
    ///  Its purpose is to get the XML file.
    /// </summary>
    public static string GetXmlPath(string fileName)
    {
        string path = @"..\..\..\Datasets";
        path = Path.Combine(path, fileName);

        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException();

        return fullPath;
    }
}
