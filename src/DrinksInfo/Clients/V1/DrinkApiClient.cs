using DrinksInfo.Application;
using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Mappings.V1;
using DrinksInfo.Application.Models;
using DrinksInfo.Contracts.Responses.V1;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Application.Clients.V1;

/// <summary>
/// The client for accessing the Drink API.
/// </summary>
public class DrinkApiClient(ApiRoutes routes) : IDrinkApiClient
{
    public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        using var client = new RestClient();

        var request = new RestRequest(routes.GetCategories);
        var reponse = await client.ExecuteAsync(request);

        if (reponse.IsSuccessStatusCode)
        {
            var content = reponse.Content;
            if (!string.IsNullOrEmpty(content))
            {
                var categories = JsonConvert.DeserializeObject<CategoriesResponse>(content)?.Values ?? [];
                return [.. categories.Select(x => x.ToCategory())];
            }
        }

        return [];
    }

    public async Task<Drink?> GetDrinkByIdAsync(string id)
    {
        var request = new RestRequest(routes.GetDrink(id));

        var drink = await GetDrink(request);

        return drink?.ToDrink();
    }

    public async Task<IReadOnlyList<Drink>> GetDrinksByCategoryNameAsync(string categoryName)
    {
        using var client = new RestClient();

        var request = new RestRequest(routes.GetDrinksByCategory(categoryName));
        var reponse = await client.ExecuteAsync(request);

        if (reponse.IsSuccessStatusCode)
        {
            var content = reponse.Content;
            if (!string.IsNullOrEmpty(content))
            {
                var drinks = JsonConvert.DeserializeObject<DrinksResponse>(content)?.Values ?? [];
                return [.. drinks.Select(x => x.ToDrink())];
            }
        }

        return [];
    }

    public async Task<Drink?> GetRandomDrinkAsync()
    {
        var request = new RestRequest(routes.GetRandomDrink);

        var drink = await GetDrink(request);

        return drink?.ToDrink();
    }

    private static async Task<DrinkResponse?> GetDrink(RestRequest request)
    {
        using var client = new RestClient();

        var reponse = await client.ExecuteAsync(request);

        if (reponse.IsSuccessStatusCode)
        {
            var content = reponse.Content;
            if (!string.IsNullOrEmpty(content))
            {
                return JsonConvert.DeserializeObject<DrinksResponse>(content)?.Values?.FirstOrDefault();
            }
        }

        return null;
    }
}
