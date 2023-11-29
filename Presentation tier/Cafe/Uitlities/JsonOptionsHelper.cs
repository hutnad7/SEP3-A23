using System.Text.Json;

namespace Cafe.Uitlities;

public static class JsonOptionsHelper
{
    public static JsonSerializerOptions DefaultJsonSerializerOptions => new JsonSerializerOptions
    {
        Converters = { new CustomDateTimeConverter() }
    };
}
