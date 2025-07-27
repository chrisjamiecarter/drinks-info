using DrinksInfo.ConsoleApp.Engines;
using DrinksInfo.ConsoleApp.Enums;
using DrinksInfo.ConsoleApp.Extensions;
using DrinksInfo.ConsoleApp.Services;
using Spectre.Console;
using System.ComponentModel;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// The main menu page of the application.
/// </summary>
internal class MainMenuPage(DrinkService drinkService,
                            SelectCategoryNamePage selectCategoryNamePage,
                            SelectDrinkPage selectDrinkPage) : BasePage
{
    private enum MainMenuPageChoices
    {
        [Description("Select drink by category")]
        SelectDrinkByCategory = 0,
        [Description("Random drink")]
        RandomDrink = 1,
        [Description("Close application")]
        CloseApplication = 2,
    }

    private const string PageTitle = "Main Menu";

    public async Task ShowAsync()
    {
        var status = PageStatus.Opened;

        while (status != PageStatus.Closed)
        {
            WriteHeader(PageTitle);

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuPageChoices>()
                .Title(PromptTitle)
                .AddChoices(Enum.GetValues<MainMenuPageChoices>())
                .UseConverter(c => c.GetDescription())
                );

            status = await PerformSelectedChoiceAsync(option);
        }
    }

    private async Task<PageStatus> PerformSelectedChoiceAsync(MainMenuPageChoices choice)
    {
        switch (choice)
        {
            case MainMenuPageChoices.SelectDrinkByCategory:

                await SelectDrinkByCategoryAsync();
                break;

            case MainMenuPageChoices.RandomDrink:

                await ViewRandomDrink();
                break;

            default:

                return PageStatus.Closed;
        }

        return PageStatus.Opened;
    }

    private async Task SelectDrinkByCategoryAsync()
    {
        var categoryName = await selectCategoryNamePage.ShowAsync();
        if (categoryName is null)
        {
            return;
        }

        var drink = await selectDrinkPage.ShowAsync(categoryName);
        if (drink is null)
        {
            return;
        }

        var table = TableEngine.GetDrinkTable(drink);
        MessagePage.Show("Selected Drink", table);
    }

    private async Task ViewRandomDrink()
    {
        var drink = await drinkService.GetRandomDrinkAsync();

        var table = TableEngine.GetDrinkTable(drink);
        MessagePage.Show("Random Drink", table);
    }
}
