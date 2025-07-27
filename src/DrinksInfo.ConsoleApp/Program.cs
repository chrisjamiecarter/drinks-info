using DrinksInfo.Abstractions;
using DrinksInfo.ConsoleApp.Services;
using DrinksInfo.ConsoleApp.Views;
using DrinksInfo.Factories;
using DrinksInfo.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DrinksInfo.ConsoleApp;

/// <summary>
/// The entry point for the application.
/// Configures the required services and middleware before running the application.
/// </summary>
internal class Program
{
    internal static void Main()
    {
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.Configure<DrinkApiClientOptions>(context.Configuration.GetSection(nameof(DrinkApiClientOptions)));
                services.AddScoped<CategoryService>();
                services.AddScoped<DrinkService>();
                services.AddSingleton<IDrinkApiClientProvider, DrinkApiClientFactory>();
                services.AddSingleton<ApiRoutes>();
                services.AddTransient<MainMenuPage>();
                services.AddTransient<SelectCategoryNamePage>();
                services.AddTransient<SelectDrinkPage>();
            })
            .Build();

        try
        {
            var mainMenuPage = host.Services.GetRequiredService<MainMenuPage>();
            mainMenuPage.Show();
        }
        catch (Exception exception)
        {
            ErrorPage.Show(exception);
        }
        finally
        {
            Environment.Exit(0);
        }
    }
}
