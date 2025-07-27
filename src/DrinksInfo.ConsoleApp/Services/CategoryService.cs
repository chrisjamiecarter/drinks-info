using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinkApiClient.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal class CategoryService(IDrinkApiClientProvider clientProvider)
{
    private readonly IDrinkApiClient client = clientProvider.CreateClient();

    public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        return await AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .StartAsync("Getting categories. Please wait...", async ctx =>
            {
                return await client.GetCategoriesAsync();
            });
    }
}
