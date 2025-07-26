using System.Text;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Views;

internal abstract class BasePage
{
    protected static readonly string ApplicationTitle = "Drinks Info";
    protected static readonly string PromptTitle = "Select an [blue]option[/]...";
    private static readonly string DividerLine = "[cyan2]----------------------------------------[/]";

    protected static void WriteFooter()
    {
        AnsiConsole.Write(new Rule().RuleStyle("grey").LeftJustified());
        AnsiConsole.Markup($"{Environment.NewLine}Press any [blue]key[/] to continue...");
        Console.ReadKey();
    }

    protected static void WriteHeader(string title)
    {
        AnsiConsole.Clear();
        AnsiConsole.Markup(GetHeaderText(title));
    }

    private static string GetHeaderText(string pageTitle)
    {
        var builder = new StringBuilder();
        builder.AppendLine(DividerLine);
        builder.AppendLine($"[bold cyan2]{ApplicationTitle}[/]: [honeydew2]{pageTitle}[/]");
        builder.AppendLine(DividerLine);
        builder.AppendLine();
        return builder.ToString();
    }
}
