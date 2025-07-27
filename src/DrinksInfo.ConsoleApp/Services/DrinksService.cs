using DrinksInfo.Clients.V1;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinkApiClient.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal static class DrinksService
{
    internal static Drink? GetDrink(string drinkId)
    {
        Drink? drink = null;

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting selected drink. Please wait...", ctx =>
            {
                var client = new DrinkApiClient();
                drink = client.GetDrinkByIdAsync(drinkId).GetAwaiter().GetResult();
            });

        return drink;
    }

    internal static IReadOnlyList<Drink> GetDrinksByCategory(string category)
    {
        IReadOnlyList<Drink> drinks = [];

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting drinks. Please wait...", ctx =>
            {
                var client = new DrinkApiClient();
                drinks = client.GetDrinksByCategoryNameAsync(category).GetAwaiter().GetResult();
            });

        return drinks;
    }

    internal static Drink? GetRandomDrink()
    {
        Drink? drink = null;

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting random drink. Please wait...", ctx =>
            {
                var client = new DrinkApiClient();
                drink = client.GetRandomDrinkAsync().GetAwaiter().GetResult();
            });

        return drink;
    }
}
