namespace ViJsonTools;

using System.Text;
using System.Text.Json;
using static JsonConfig;

public static class JsonUtilities
{
    /// <summary>
    ///  Serializes an DTO to an JSON formatted string.
    /// </summary>
    public static string Serialize(object collection)
        => JsonSerializer.Serialize(collection, options);

    /// <summary>
    ///  Serializes an DTO to an JSON formatted string with custom options.
    /// </summary>
    public static string Serialize(object collection, JsonSerializerOptions options)
        => JsonSerializer.Serialize(collection, options);

    /// <summary>
    ///  Async method.
    ///  Serializes an DTO to an JSON formatted string.
    /// </summary>
    public async static Task<string> SerializeAsync(object collection)
    {
        using MemoryStream stream = new();
        await JsonSerializer.SerializeAsync(stream, collection, options);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    /// <summary>
    ///  Async method.
    ///  Serializes an DTO to an JSON formatted string with custom options.
    /// </summary>
    public async static Task<string> SerializeAsync(object collection, JsonSerializerOptions options)
    {
        using MemoryStream stream = new();
        await JsonSerializer.SerializeAsync(stream, collection, options);
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    /// <summary>
    ///  Deserializes an JSON formatted string into an array of DTOs.
    /// </summary>
    public static T[] Deserialize<T>(string input)
        => JsonSerializer.Deserialize<T[]>(input, options) ?? Array.Empty<T>();

    /// <summary>
    ///  Deserializes an JSON formatted string into an array of DTOs with custom options.
    /// </summary>
    public static T[] Deserialize<T>(string input, JsonSerializerOptions options)
        => JsonSerializer.Deserialize<T[]>(input, options) ?? Array.Empty<T>();

    /// <summary>
    ///  Async method.
    ///  Deserializes an JSON formatted string into an array of DTOs.
    /// </summary>
    public async static Task<T[]> DeserializeAsync<T>(string input)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(input);
        using MemoryStream stream = new(byteArray);

        return await JsonSerializer.DeserializeAsync<T[]>(stream, options) ?? Array.Empty<T>();
    }

    /// <summary>
    ///  Async method.
    ///  Deserializes an JSON formatted string into an array of DTOs with custom options
    /// </summary>
    public async static Task<T[]> DeserializeAsync<T>(string input, JsonSerializerOptions options)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(input);
        using MemoryStream stream = new(byteArray);

        return await JsonSerializer.DeserializeAsync<T[]>(stream, options) ?? Array.Empty<T>();
    }

    /// <summary>
    ///  This method is made specificly for SoftUni exercises and its file structure.
    ///  Its purpose is to get the JSON file.
    /// </summary>
    public static string GetJsonPath(string fileName)
    {
        string path = @"..\..\..\Datasets";
        path = Path.Combine(path, fileName);

        string fullPath = Path.GetFullPath(path);
        if (!File.Exists(fullPath)) throw new FileNotFoundException();

        return fullPath;
    }
}
