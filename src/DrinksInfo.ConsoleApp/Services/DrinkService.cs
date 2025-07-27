using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinkApiClient.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal class DrinkService(IDrinkApiClientProvider clientProvider)
{
    private readonly IDrinkApiClient client  = clientProvider.CreateClient();

    public async Task<Drink?> GetDrinkAsync(string drinkId)
    {
        return await AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .StartAsync("Getting selected drink. Please wait...", async ctx =>
            {
                return await client.GetDrinkByIdAsync(drinkId);
            });
    }

    public async Task<IReadOnlyList<Drink>> GetDrinksByCategoryAsync(string category)
    {
        return await AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .StartAsync("Getting drinks. Please wait...", async ctx =>
            {
                return await client.GetDrinksByCategoryNameAsync(category);
            });
    }

    public async Task<Drink?> GetRandomDrinkAsync()
    {
        return await AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .StartAsync("Getting random drink. Please wait...", async ctx =>
            {
                return await client.GetRandomDrinkAsync();
            });
    }
}
