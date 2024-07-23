using DrinksInfo.Contracts;
using DrinksInfo.Services;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Services;

internal class UserInputService
{
    DrinksService drinksService = new();

    internal static string GetCategoriesInput()
    {
        return AnsiConsole.Ask<string>("Choose category: ");
    }

    internal static string GetDrinksInput()
    {
        return AnsiConsole.Ask<string>("Choose drink: ");
    }
}
