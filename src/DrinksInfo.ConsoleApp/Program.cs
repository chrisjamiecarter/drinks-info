using DrinksInfo.ConsoleApp.Views;

namespace DrinksInfo.ConsoleApp;

internal class Program
{
    static void Main()
    {
        try
        {
            MainMenuPage.Show();
        }
        catch (Exception exception)
        {
            MessagePage.Show("Error", exception);
        }
        finally
        {
            Environment.Exit(0);
        }
    }
}
