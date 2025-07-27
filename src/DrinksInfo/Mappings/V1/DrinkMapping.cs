using DrinksInfo.Application.Models;
using DrinksInfo.Contracts.Responses.V1;

namespace DrinksInfo.Application.Mappings.V1;

internal static class DrinkMapping
{
    public static Drink ToDrink(this DrinkResponse response)
    {
        return new Drink
        {
            Id = response.Id ?? string.Empty,
            Name = response.Name ?? string.Empty,
            DrinkAlternate = response.DrinkAlternate ?? string.Empty,
            Tags = response.Tags ?? string.Empty,
            Video = response.Video ?? string.Empty,
            Category = response.Category ?? string.Empty,
            Iba = response.Iba ?? string.Empty,
            Alcoholic = response.Alcoholic ?? string.Empty,
            Glass = response.Glass ?? string.Empty,
            Instructions = response.Instructions ?? string.Empty,
            DrinkThumb = response.DrinkThumb ?? string.Empty,
            Ingredient1 = response.Ingredient1 ?? string.Empty,
            Ingredient2 = response.Ingredient2 ?? string.Empty,
            Ingredient3 = response.Ingredient3 ?? string.Empty,
            Ingredient4 = response.Ingredient4 ?? string.Empty,
            Ingredient5 = response.Ingredient5 ?? string.Empty,
            Ingredient6 = response.Ingredient6 ?? string.Empty,
            Ingredient7 = response.Ingredient7 ?? string.Empty,
            Ingredient8 = response.Ingredient8 ?? string.Empty,
            Ingredient9 = response.Ingredient9 ?? string.Empty,
            Ingredient10 = response.Ingredient10 ?? string.Empty,
            Ingredient11 = response.Ingredient11 ?? string.Empty,
            Ingredient12 = response.Ingredient12 ?? string.Empty,
            Ingredient13 = response.Ingredient13 ?? string.Empty,
            Ingredient14 = response.Ingredient14 ?? string.Empty,
            Ingredient15 = response.Ingredient15 ?? string.Empty,
            Measure1 = response.Measure1 ?? string.Empty,
            Measure2 = response.Measure2 ?? string.Empty,
            Measure3 = response.Measure3 ?? string.Empty,
            Measure4 = response.Measure4 ?? string.Empty,
            Measure5 = response.Measure5 ?? string.Empty,
            Measure6 = response.Measure6 ?? string.Empty,
            Measure7 = response.Measure7 ?? string.Empty,
            Measure8 = response.Measure8 ?? string.Empty,
            Measure9 = response.Measure9 ?? string.Empty,
            Measure10 = response.Measure10 ?? string.Empty,
            Measure11 = response.Measure11 ?? string.Empty,
            Measure12 = response.Measure12 ?? string.Empty,
            Measure13 = response.Measure13 ?? string.Empty,
            Measure14 = response.Measure14 ?? string.Empty,
            Measure15 = response.Measure15 ?? string.Empty,
        };
    }
}
