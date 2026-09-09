namespace ViJsonTools;

using System.Text;
using System.Text.Json;

public static class JsonUtilities
{
    /// <summary>
    ///  Imports from JSON formated string to a given DTO.
    /// </summary>
    public static T[] Deserialize<T>(string input)
        => JsonSerializer.Deserialize<T[]>(input, JsonConfig.options) ?? Array.Empty<T>();

    /// <summary>
    ///  Async version.
    ///  Imports from JSON formated string to a given DTO.
    /// </summary>
    public async static Task<T[]> DeserializeAsync<T>(string input)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(input);
        using MemoryStream stream = new(byteArray);

        return await JsonSerializer.DeserializeAsync<T[]>(stream, JsonConfig.options) ?? Array.Empty<T>();
    }

    public static string Serialize(object collection)
        => JsonSerializer.Serialize(collection, JsonConfig.options);

    public static string Serialize(object collection, JsonSerializerOptions options)
        => JsonSerializer.Serialize(collection, options);

    public async static Task<string> SerializeAsync(object collection)
    {
        using MemoryStream stream = new();
        await JsonSerializer.SerializeAsync(stream, collection, JsonConfig.options);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public static string GetJsonPath(string fileName)
    {
        string path = @"Datasets\";
        path = Path.Combine(path, fileName);

        return Path.GetFullPath(path);
    }
}
