using System.ComponentModel;

namespace DrinksInfo.ConsoleApp.Extensions;

/// <summary>
/// System.Enum extension methods.
/// </summary>
internal static class EnumExtensions
{
    /// <summary>
    /// Gets the ComponentModel.DescriptionAttribute value of an enum value.
    /// Used to retrieve a user-friendly description for enum values.
    /// </summary>
    /// <param name="value">The enum value to get the description of.</param>
    /// <returns>Returns the description attribute of the enum value if it has one; else, the enum value as <c>string</c></returns>
    public static string GetDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo is null)
        {
            return value.ToString();
        }

        return fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes 
            && attributes.Length > 0 
            ? attributes.First().Description 
            : value.ToString();
    }
}
