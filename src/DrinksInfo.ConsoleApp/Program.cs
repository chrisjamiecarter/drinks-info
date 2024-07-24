using DrinksInfo.ConsoleApp.Engines;
using DrinksInfo.ConsoleApp.Services;
using DrinksInfo.Controllers.V1;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var categories = DrinksController.GetCategories();
        TableVisualisationEngine.ShowCategories(categories);

        string category = UserInputService.GetCategoriesInput();
        while (!InputValidationService.IsValidCategory(category, categories))
        {
            AnsiConsole.WriteLine("Invalid category");
            category = UserInputService.GetCategoriesInput();
        }

        var drinks = DrinksController.GetDrinksByCategory(category);
        TableVisualisationEngine.ShowDrinks(drinks);

        string drink = UserInputService.GetDrinksInput();
        while (!InputValidationService.IsValidDrink(drink, drinks))
        {
            AnsiConsole.WriteLine("Invalid drink");
            drink = UserInputService.GetDrinksInput();
        }

        var drinkDetail = DrinksController.GetDrinkDetail(drinks.First(x => x.Name!.Equals(drink)).Id!);
        TableVisualisationEngine.ShowDrinkDetail(drinkDetail!);

        Console.ReadKey();

        var randomDrinkDetail = DrinksController.GetRandomDrinkDetail();
        TableVisualisationEngine.ShowDrinkDetail(randomDrinkDetail!);


        Console.ReadKey();

    }
}
