using System.Text.Json.Serialization;
using System.Text.Json;

namespace University_API.Helpers;

public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    private const string _timeFormat = "HH:mm:ss"; 

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return TimeOnly.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_timeFormat));
    }
}
