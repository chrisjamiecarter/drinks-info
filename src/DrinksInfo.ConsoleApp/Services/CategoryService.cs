using DrinksInfo.Abstractions;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

/// <summary>
/// Service to interact with the DrinkApiClient.
/// Uses Status and Spinner due to delay in API reponse times.
/// </summary>
internal class CategoryService(IDrinkApiClientProvider clientProvider)
{
    private readonly IDrinkApiClient client = clientProvider.CreateClient();

    public IReadOnlyList<Category> GetCategories()
    {
        return AnsiConsole
            .Status()
            .Spinner(Spinner.Known.Aesthetic)
            .Start("Getting categories. Please wait...", ctx =>
            {
                return client.GetCategoriesAsync().GetAwaiter().GetResult();
            });
    }
}
