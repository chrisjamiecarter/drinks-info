using DrinksInfo.Contracts;
using DrinksInfo.Controllers.V1;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

internal class UserInputService
{
    DrinksController drinksService = new();

    internal static string GetCategoriesInput()
    {
        return AnsiConsole.Ask<string>("Choose category: ");
    }

    internal static string GetDrinksInput()
    {
        return AnsiConsole.Ask<string>("Choose drink: ");
    }
}
