using DrinksInfo.Application.Models;
using DrinksInfo.ConsoleApp.Models;
using DrinksInfo.ConsoleApp.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of drinks for selection.
/// </summary>
internal class SelectDrinkPage(DrinkService drinkService) : BasePage
{
    private const string PageTitle = "Select Drink";
    
    private static IEnumerable<UserChoice> PageChoices
    {
        get
        {
            return
            [
                new(0, "Close page")
            ];
        }
    }

    /// <summary>
    /// Shows a list of drinks and gets the users selection.
    /// </summary>
    /// <param name="category">The category of the drinks to be displayed.</param>
    /// <returns>The name of the category selected, or null if user wants to close the page.</returns>
    internal async Task<Drink?> ShowAsync(string category)
    {
        WriteHeader(PageTitle);

        var drinks = await drinkService.GetDrinksByCategoryAsync(category);

        var option = GetOption(drinks);

        return option.Id == 0 
            ? null 
            : await drinkService.GetDrinkAsync(drinks.First(x => x.Name == option.Name).Id);
    }

    private static UserChoice GetOption(IReadOnlyList<Drink> drinks)
    {
        // Add the list to the existing PageChoices
        // Note: we do not care about the id, but it can't be 0 (close page).
        IEnumerable<UserChoice> pageChoices = [.. drinks.Select(x => new UserChoice(1, x.Name!)), .. PageChoices];

        return AnsiConsole.Prompt(
                new SelectionPrompt<UserChoice>()
                .Title(PromptTitle)
                .EnableSearch()
                .AddChoices(pageChoices)
                .UseConverter(c => c.Name!)
                );
    }
}
