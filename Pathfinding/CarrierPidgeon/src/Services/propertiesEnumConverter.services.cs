using System.Text.Json;
using System.Text.Json.Serialization;
using CarrierPidgeon.Types;

namespace CarrierPidgeon.Services
{
    public class PropertiesEnumConverter : JsonConverter<List<Enum>>
    {
        public override List<Enum> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var result = new List<Enum>();
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType == JsonTokenType.String)
                    {
                        Enum enumValue;
                        var propertyValue = reader.GetString();

                        // Determine context based on propertyValue or other criteria
                        if (Enum.IsDefined(typeof(NodeProperties), propertyValue))
                        {
                            enumValue = (NodeProperties)Enum.Parse(typeof(NodeProperties), propertyValue);
                        }
                        else if (Enum.IsDefined(typeof(UniqueNodeProperties), propertyValue))
                        {
                            enumValue = (UniqueNodeProperties)Enum.Parse(typeof(UniqueNodeProperties), propertyValue);
                        }
                        else
                        {
                            throw new JsonException("Invalid context for propertyValue");
                        }

                        result.Add(enumValue);
                    }
                }
                return result;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, List<Enum> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}