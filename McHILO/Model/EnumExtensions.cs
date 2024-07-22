using System.Reflection;

namespace McHILO.Model
{
    public static class EnumExtensions
    {
        public static string GetMessage(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            MessageAttribute attribute = field.GetCustomAttribute<MessageAttribute>();

            return attribute == null ? value.ToString() : attribute.Message;
        }
    }
}
