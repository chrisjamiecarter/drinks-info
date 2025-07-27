using DrinksInfo.Application.Models;
using DrinksInfo.ConsoleApp.Models;
using DrinksInfo.ConsoleApp.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page to displays a list of categories for selection.
/// </summary>
internal class SelectCategoryNamePage(CategoryService categoryService) : BasePage
{
    private const string PageTitle = "Select Category";

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
    /// Shows a list of categories and gets the users selection.
    /// </summary>
    /// <returns>The name of the category selected, or null if user wants to close the page.</returns>
    internal async Task<string?> ShowAsync()
    {
        WriteHeader(PageTitle);
        
        var categories = await categoryService.GetCategoriesAsync();

        var option = GetOption(categories);

        return option.Id == 0 ? null : option.Name;
    }

    private static UserChoice GetOption(IReadOnlyList<Category> categories)
    {
        // Add the list to the existing PageChoices
        // Note: we do not care about the id, but it can't be 0 (close page).
        IEnumerable<UserChoice> pageChoices = [.. categories.Select(x => new UserChoice(1, x.Name!)), .. PageChoices];

        return AnsiConsole.Prompt(
                new SelectionPrompt<UserChoice>()
                .Title(PromptTitle)
                .EnableSearch()
                .AddChoices(pageChoices)
                .PageSize(15)
                .UseConverter(c => c.Name!)
                );
    }
}
