using DrinksInfo.Contracts.Responses.V1;
using DrinksInfo.Mappings.V1;
using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Web;

namespace DrinksInfo.Clients.V1;

/// <summary>
/// The client for accessing the Drink API.
/// </summary>
public class DrinkApiClient : IDrinkApiClient
{
    public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.GetCategories);
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
        var request = new RestRequest(ApiRoutes.GetDrink.Replace("{id}", HttpUtility.UrlEncode(id)));

        var drink = await GetDrink(request);

        return drink?.ToDrink();
    }

    public async Task<IReadOnlyList<Drink>> GetDrinksByCategoryNameAsync(string categoryName)
    {
        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.GetDrinksByCategory.Replace("{category}", HttpUtility.UrlEncode(categoryName)));
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
        var request = new RestRequest(ApiRoutes.GetRandomDrink);

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
