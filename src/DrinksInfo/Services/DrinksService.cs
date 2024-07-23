using System.Web;
using DrinksInfo.Contracts;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Services;

public class DrinksService
{
    string endpointBaseUrl = "http://www.thecocktaildb.com/api/json/v1/1/";

    public List<Category> GetCategories()
    {
        List<Category> categories = [];

        using var client = new RestClient(endpointBaseUrl);

        var request = new RestRequest("list.php?c=list");
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            string rawResponse = reponse.Result.Content!;
            var jsonReponse = JsonConvert.DeserializeObject<Categories>(rawResponse);

            categories = jsonReponse!.CategoriesList!;
        }

        return categories;
    }

    public List<Drink> GetDrinksByCategory(string category)
    {
        List<Drink> drinks = [];

        using var client = new RestClient(endpointBaseUrl);

        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            string rawResponse = reponse.Result.Content!;
            var jsonReponse = JsonConvert.DeserializeObject<Drinks>(rawResponse);

            drinks = jsonReponse!.DrinksList!;
        }

        return drinks;
    }

    public DrinkDetail? GetDrinkDetail(string drink)
    {
        List<DrinkDetail> drinkDetails = [];

        using var client = new RestClient(endpointBaseUrl);

        var request = new RestRequest($"lookup.php?i={HttpUtility.UrlEncode(drink)}");
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            string rawResponse = reponse.Result.Content!;
            var jsonReponse = JsonConvert.DeserializeObject<DrinkDetails>(rawResponse);

            drinkDetails = jsonReponse!.DrinkDetailsList!;
        }

        return drinkDetails.FirstOrDefault();
    }
}
