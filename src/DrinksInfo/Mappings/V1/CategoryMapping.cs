using DrinksInfo.Contracts.Responses.V1;
using DrinksInfo.Models;

namespace DrinksInfo.Mappings.V1;

internal static class CategoryMapping
{
    public static Category ToCategory(this CategoryResponse response)
    {
        return new Category
        {
            Name = response.Name ?? string.Empty,
        };
    }
}
