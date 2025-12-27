using System.ComponentModel;
using System.Reflection;

namespace Domain.Models.ContactForm.Enums;

public static class GetEnumDescription
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field.GetCustomAttribute<DescriptionAttribute>();
        return attr?.Description ?? value.ToString();
    }
}