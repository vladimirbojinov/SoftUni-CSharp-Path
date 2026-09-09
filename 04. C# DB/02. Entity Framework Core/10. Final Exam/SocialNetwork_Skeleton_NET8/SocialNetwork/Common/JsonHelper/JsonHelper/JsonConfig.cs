namespace ViJsonTools;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonConfig
{
    public static readonly JsonSerializerOptions options = new()
    {
        //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };
}
