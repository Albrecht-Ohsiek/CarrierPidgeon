using CarrierPidgeon.Types;

namespace CarrierPidgeon.Models
{
    public class EnumInfo : IEnumInfo
    {
        public string type { get; set; }
        public string value { get; set; }

        public Enum GetEnumValue()
        {
            if (type == null)
            {
                throw new InvalidOperationException("The 'property' property is null.");
            }
            
            Type enumType = Type.GetType(type);
            if (enumType == null || !enumType.IsEnum)
            {
                throw new InvalidOperationException($"Invalid enum type '{type}'.");
            }

            if (Enum.TryParse(enumType, value, ignoreCase: true, out object enumValueObj) && enumValueObj is Enum enumValue)
            {
                return enumValue;
            }

            throw new InvalidOperationException($"Invalid value '{value}' for enum type '{type}'.");
        }
    }
}