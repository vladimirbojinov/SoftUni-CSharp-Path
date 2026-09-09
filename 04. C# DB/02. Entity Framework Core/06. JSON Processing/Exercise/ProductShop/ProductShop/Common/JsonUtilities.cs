namespace ViJsonTools;

using System.Text.Json;

public static class JsonUtilities
{
    public static T[] Deserialize<T>(string input)
        => JsonSerializer.Deserialize<T[]>(input, JsonConfig.options) ?? Array.Empty<T>();

    public static string Serialize(object collection)
    => JsonSerializer.Serialize(collection, JsonConfig.options);

    public static string Serialize(object collection, JsonSerializerOptions options)
        => JsonSerializer.Serialize(collection, options);

    public static string GetJsonPath(string file)
    {
        string path = @"..\..\..\Datasets";
        path = Path.Combine(path, file);

        return Path.GetFullPath(path);
    }
}
