using System.Text.Json;
using System.Text.Json.Serialization;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Serializer
{
    public class NodePropertiesConverter : JsonConverter<List<EnumInfo>>
    {
        public override List<EnumInfo> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var result = new List<EnumInfo>();
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        EnumInfo enumInfo = JsonSerializer.Deserialize<EnumInfo>(ref reader, options);
                        result.Add(enumInfo);
                    }
                }
                return result;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, List<EnumInfo> value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStartArray();
                foreach (var enumInfo in value)
                {
                    JsonSerializer.Serialize(writer, enumInfo, options);
                }
                writer.WriteEndArray();
            }
        }
    }
}