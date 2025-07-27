using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

/// <summary>
/// A page which displays a parameterised exception and title.
/// </summary>
internal class ErrorPage : BasePage
{
    public const string Title = "Error";

    public static void Show(Exception exception)
    {
        WriteHeader(Title);

        AnsiConsole.WriteException(exception, ExceptionFormats.NoStackTrace);

        WriteFooter();
    }
}
