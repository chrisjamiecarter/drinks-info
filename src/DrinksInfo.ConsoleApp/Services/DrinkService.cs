using DrinksInfo.Abstractions;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinkApiClient.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal class DrinkService(IDrinkApiClientProvider clientProvider)
{
    private readonly IDrinkApiClient client  = clientProvider.CreateClient();

    public Drink? GetDrink(string drinkId)
    {
        return AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting selected drink. Please wait...", ctx =>
            {
                return client.GetDrinkByIdAsync(drinkId).GetAwaiter().GetResult();
            });
    }

    public IReadOnlyList<Drink> GetDrinksByCategory(string category)
    {
        return AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting drinks. Please wait...", ctx =>
            {
                return client.GetDrinksByCategoryNameAsync(category).GetAwaiter().GetResult();
            });
    }

    public Drink? GetRandomDrink()
    {
        return AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting random drink. Please wait...", ctx =>
            {
                return client.GetRandomDrinkAsync().GetAwaiter().GetResult();
            });
    }
}
