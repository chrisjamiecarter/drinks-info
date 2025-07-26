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
internal class MainMenuPage : BasePage
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
    
    internal static void Show()
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

            status = PerformSelectedChoice(option);
        }
    }

    private static PageStatus PerformSelectedChoice(MainMenuPageChoices choice)
    {
        switch (choice)
        {
            case MainMenuPageChoices.SelectDrinkByCategory:

                SelectDrinkByCategory();
                break;

            case MainMenuPageChoices.RandomDrink:

                ViewRandomDrink();
                break;

            default:

                return PageStatus.Closed;
        }

        return PageStatus.Opened;
    }

    private static void SelectDrinkByCategory()
    {
        var categoryName = SelectCategoryNamePage.Show();
        if (categoryName == null)
        {
            return;
        }

        var drink = SelectDrinkPage.Show(categoryName);
        if (drink == null)
        {
            return;
        }

        var table = TableEngine.GetDrinkTable(drink);

        MessagePage.Show("Selected Drink", table);
    }

    private static void ViewRandomDrink()
    {
        var drink = DrinksService.GetRandomDrink();

        var table = TableEngine.GetDrinkTable(drink!);

        MessagePage.Show("Random Drink", table);
    }
}
