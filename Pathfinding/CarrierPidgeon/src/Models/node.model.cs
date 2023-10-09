using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CarrierPidgeon.Serializer;
using CarrierPidgeon.Types;

namespace CarrierPidgeon.Models
{
    public class Node : INode
    {
        [Required]
        public int posX{get; set;}
        [Required]
        public int posY{get; set;}
        [Required]
        public bool occupied { get; set; }
        [Required]
        public bool accessible { get; set; }
        public int gCost { get; set; }
        public int hCost { get; set; }
        public int fCost { get; set; }
        [JsonConverter(typeof(NodePropertiesConverter))]
        public List<Enum> properties { get; set; }
        [JsonIgnore]
        public List<Node> _origin {get; set;}
        [JsonConverter(typeof(NodeOriginConverter))]
        public List<Node> origin 
        {
            get 
            {
                if (_origin == null) {
                    _origin = new List<Node>();
                }
                return _origin;
            } 
            set => _origin = value;
        }

        public Node()
        {

        }

        public Node(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.occupied = false;
            this.accessible = true;
            this.gCost = 0;
            this.hCost = 0;
            this.fCost = 0;
            this.properties = new List<Enum>();
            this.origin = new List<Node>();
        }

        [JsonConstructor]
        internal Node(int posX, int posY, bool isOccupied, bool isAccessible, int calculatedFCost, int calculatedGCost, int calculatedHCost, List<Enum> properties, List<Node> origin)
        {
            this.posX = posX;
            this.posY = posY;
            this.occupied = isOccupied;
            this.accessible = isAccessible;
            this.fCost = calculatedFCost;
            this.gCost = calculatedGCost;
            this.hCost = calculatedHCost;
            this.properties = properties;
            this.origin = origin;
        }

        public void ConvertPropertiesToEnums()
    {
        Dictionary<string, Type> enumTypeMappings = new Dictionary<string, Type>
        {
            { "UniqueNodeProperties", typeof(UniqueNodeProperties) },
            { "NodeProperties", typeof(NodeProperties) },
            // Add more mappings as needed
        };

        List<Enum> properties = new List<Enum>();
        foreach (var property in properties.Cast<EnumInfo>())
        {
            if (enumTypeMappings.TryGetValue(property.value, out var enumType))
            {
                Enum enumValue = (Enum)Enum.Parse(enumType, property.value);
                properties.Add(enumValue);
            }
            else
            {
                throw new InvalidOperationException($"Invalid enum type '{property.value}'.");
            }
        }

        this.properties = properties;
    }
    }
}