using DrinksInfo.Application.Models;
using DrinksInfo.Contracts.Responses.V1;

namespace DrinksInfo.Application.Mappings.V1;

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
