using DrinksInfo.Application;
using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Factories;
using DrinksInfo.Application.Options;
using DrinksInfo.ConsoleApp.Services;
using DrinksInfo.ConsoleApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;

namespace DrinksInfo.ConsoleApp;

/// <summary>
/// The entry point for the application.
/// Configures the required services and middleware before running the application.
/// </summary>
internal class Program
{
    internal static async Task Main()
    {
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.Configure<DrinkApiClientOptions>(context.Configuration.GetSection(nameof(DrinkApiClientOptions)));
                services.AddScoped<CategoryService>();
                services.AddScoped<DrinkService>();
                services.AddSingleton<IDrinkApiClientProvider, DrinkApiClientFactory>();
                services.AddSingleton<ApiRoutes>();
                services.AddTransient<IRestClient, RestClient>();
                services.AddTransient<MainMenuPage>();
                services.AddTransient<SelectCategoryNamePage>();
                services.AddTransient<SelectDrinkPage>();
            })
            .Build();

        try
        {
            var mainMenuPage = host.Services.GetRequiredService<MainMenuPage>();
            await mainMenuPage.ShowAsync();
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
