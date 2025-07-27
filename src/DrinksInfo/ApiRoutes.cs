using System.Web;
using DrinksInfo.Application.Options;
using Microsoft.Extensions.Options;

namespace DrinksInfo.Application;

/// <summary>
/// The supported API routes in this application.
/// </summary>
public class ApiRoutes(IOptions<DrinkApiClientOptions> options)
{
    private readonly DrinkApiClientOptions _options = options.Value;

    private string Base => @$"{_options.Root}\{_options.Version}\{_options.Key}";
 
    public string GetCategories => $"{Base}/list.php?c=list";
    public string GetRandomDrink => $"{Base}/random.php";
    
    public string GetDrink(string id) => 
        $"{Base}/lookup.php?i={HttpUtility.UrlEncode(id)}";
    
    public string GetDrinksByCategory(string categoryName) => 
        $"{Base}/filter.php?c={HttpUtility.UrlEncode(categoryName)}";
}
