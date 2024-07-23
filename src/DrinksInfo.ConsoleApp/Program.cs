using DrinksInfo.ConsoleApp.Engines;
using DrinksInfo.ConsoleApp.Services;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var drinksService = new DrinksService();

        var categories = drinksService.GetCategories();
        TableVisualisationEngine.ShowCategories(categories);

        string category = UserInputService.GetCategoriesInput();
        while (!InputValidationService.IsValidCategory(category, categories))
        {
            AnsiConsole.WriteLine("Invalid category");
            category = UserInputService.GetCategoriesInput();
        }

        var drinks = drinksService.GetDrinksByCategory(category);
        TableVisualisationEngine.ShowDrinks(drinks);

        string drink = UserInputService.GetDrinksInput();
        while (!InputValidationService.IsValidDrink(drink, drinks))
        {
            AnsiConsole.WriteLine("Invalid drink");
            drink = UserInputService.GetDrinksInput();
        }

        var drinkDetail = drinksService.GetDrinkDetail(drinks.First(x => x.Name!.Equals(drink)).Id!);
        TableVisualisationEngine.ShowDrinkDetail(drinkDetail);

    }
}
