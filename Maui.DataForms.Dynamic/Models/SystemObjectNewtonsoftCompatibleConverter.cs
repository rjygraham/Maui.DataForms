using System.Text.Json;
using System.Text.Json.Serialization;

namespace Maui.DataForms.Models;

public class SystemObjectNewtonsoftCompatibleConverter : JsonConverter<object>
{
    public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.True)
        {
            return true;
        }

        if (reader.TokenType == JsonTokenType.False)
        {
            return false;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt16(out short s))
            {
                return s;
            }

            if (reader.TryGetInt32(out int i))
            {
                return i;
            }

            if (reader.TryGetInt64(out long l))
            {
                return l;
            }

            return reader.GetDouble();
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();

            if (s.Contains('+', StringComparison.OrdinalIgnoreCase))
            {
                if (DateTimeOffset.TryParse(s, out DateTimeOffset dateTimeOffset))
                {
                    return dateTimeOffset;
                }
            }

            if (DateTime.TryParse(s, out DateTime datetime))
            {
                return datetime;
            }

            return s;
        }

        // Use JsonElement as fallback.
        // Newtonsoft uses JArray or JObject.
        using (JsonDocument document = JsonDocument.ParseValue(ref reader))
        {
            return document.RootElement.Clone();
        }
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        throw new InvalidOperationException("Should not get here.");
    }
}
