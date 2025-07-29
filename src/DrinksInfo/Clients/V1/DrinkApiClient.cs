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
public class DrinkApiClient(ApiRoutes routes, IRestClient restClient) : IDrinkApiClient
{
    public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
    {
        var request = new RestRequest(routes.GetCategories);
        var response = await restClient.GetAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content;
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
        var request = new RestRequest(routes.GetDrinksByCategory(categoryName));
        var reponse = await restClient.GetAsync(request);

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

    private async Task<DrinkResponse?> GetDrink(RestRequest request)
    {
        var reponse = await restClient.GetAsync(request);

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
