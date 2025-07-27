using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page which displays a parameterised message and title.
/// </summary>
internal class MessagePage : BasePage
{
    public static void Show(string title, Table table)
    {
        WriteHeader(title);

        AnsiConsole.Write(table);

        WriteFooter();
    }
}
