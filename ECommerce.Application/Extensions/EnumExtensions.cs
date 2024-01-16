using ECommerce.Application.Models.Common;

namespace ECommerce.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);
            dynamic displayAttribute = null;
            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            return displayAttribute?.Description ?? "";
        }

        public static EnumValueDescription GetValueDescription(this Enum value)
        {
            var dto = new EnumValueDescription();
            dto.Value = value;
            dto.Description = value.Description();
            return dto;
        }

        public static List<EnumValueDescription> GetEnumValueDescriptionList<T>() where T : Enum
        {
            var list = new List<EnumValueDescription>();
            Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToList()
                .ForEach(x => list.Add(x.GetValueDescription()));

            return list;
        }
    }
}
