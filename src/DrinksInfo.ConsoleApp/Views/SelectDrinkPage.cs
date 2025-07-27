using DrinksInfo.ConsoleApp.Models;
using DrinksInfo.ConsoleApp.Services;
using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of drinks for selection.
/// </summary>
internal class SelectDrinkPage : BasePage
{
    private const string PageTitle = "Select Drink";
    
    internal static IEnumerable<UserChoice> PageChoices
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
    /// Gets a list of drinks from the drink api client for a given category and displays for user selection.
    /// </summary>
    /// <param name="category">The category of the drinks to be displayed.</param>
    /// <returns>The name of the category selected, or null if user wants to close the page.</returns>
    internal static Drink? Show(string category)
    {
        var drinks = DrinksService.GetDrinksByCategory(category);

        WriteHeader(PageTitle);

        var option = GetOption(drinks);

        if (option.Id == 0)
        {
            return null;
        }
        else
        {
            return DrinksService.GetDrink(drinks.First(x => x.Name == option.Name).Id!);
        }
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
