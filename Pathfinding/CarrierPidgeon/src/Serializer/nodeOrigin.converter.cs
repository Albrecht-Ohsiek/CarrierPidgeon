using System.Text.Json;
using System.Text.Json.Serialization;
using CarrierPidgeon.Models;

namespace CarrierPidgeon.Serializer
{
    public class NodeOriginConverter : JsonConverter<Node>
    {
        private const int MaxDepth = 1;

        public override Node Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DeserializeNode(ref reader, options, 0);
        }


        public override void Write(Utf8JsonWriter writer, Node node, JsonSerializerOptions options)
        {
            SerializeNode(writer, node, options, 0);
        }

        private Node DeserializeNode(ref Utf8JsonReader reader, JsonSerializerOptions options, int depth)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            Node node = new Node();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case "posX":
                            node.posX = reader.GetInt32();
                            break;
                        case "posY":
                            node.posY = reader.GetInt32();
                            break;
                        case "occupied":
                            node.occupied = reader.GetBoolean();
                            break;
                        case "accessible":
                            node.accessible = reader.GetBoolean();
                            break;
                        case "gCost":
                            node.gCost = reader.GetInt32();
                            break;
                        case "hCost":
                            node.hCost = reader.GetInt32();
                            break;
                        case "fCost":
                            node.fCost = reader.GetInt32();
                            break;
                        case "properties":
                            node.properties = JsonSerializer.Deserialize<List<EnumInfo>>(ref reader, options)
                                .Select(enumInfo => enumInfo.GetEnumValue())
                                .ToList();
                            break;
                        case "origin":
                            if (depth < MaxDepth)
                            {
                                node.origin = JsonSerializer.Deserialize<List<Node>>(ref reader, options);
                            }
                            else
                            {
                                reader.Skip(); // Skip origin if depth is too deep
                            }
                            break;
                        default:
                            reader.Skip(); // Skip unknown properties
                            break;
                    }
                }
            }

            return node;
        }

        private void SerializeNode(Utf8JsonWriter writer, Node node, JsonSerializerOptions options, int depth)
        {
            writer.WriteStartObject();

            writer.WriteNumber("posX", node.posX);
            writer.WriteNumber("posY", node.posY);
            writer.WriteBoolean("occupied", node.occupied);
            writer.WriteBoolean("accessible", node.accessible);
            writer.WriteNumber("gCost", node.gCost);
            writer.WriteNumber("hCost", node.hCost);
            writer.WriteNumber("fCost", node.fCost);
            writer.WritePropertyName("properties");

            writer.WriteStartArray();
            foreach (var enumValue in node.properties)
            {
                writer.WriteStringValue(enumValue.ToString());
            }
            writer.WriteEndArray();

            if (depth < MaxDepth)
            {
                writer.WritePropertyName("origin");
                JsonSerializer.Serialize(writer, node.origin, options);
            }

            writer.WriteEndObject();

        }
    }
}