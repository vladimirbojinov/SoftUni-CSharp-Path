namespace ViXmlTools;

using System.Xml.Serialization;

public static class XmlUtilities
{
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

    public static string GetXmlPath(string file)
    {
        string path = @"..\..\..\Datasets";
        path = Path.Combine(path, file);

        return Path.GetFullPath(path);
    }
}
