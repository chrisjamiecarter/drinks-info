using System.Web;
using DrinksInfo.Contracts;
using DrinksInfo.Contracts.V1;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo.Controllers.V1;

public class DrinksController
{
    public static List<Category> GetCategories()
    {
        List<Category> categories = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.Categories.GetAll);
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            categories = JsonConvert.DeserializeObject<Categories>(reponse.Result.Content!)!.CategoriesList!;
        }

        return categories;
    }

    public static List<Drink> GetDrinksByCategory(string category)
    {
        List<Drink> drinks = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.Drinks.GetByCategory.Replace("{category}", HttpUtility.UrlEncode(category)));
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            drinks = JsonConvert.DeserializeObject<Drinks>(reponse.Result.Content!)!.DrinksList!;
        }

        return drinks;
    }

    public static DrinkDetail? GetDrinkDetail(string drinkId)
    {
        List<DrinkDetail> drinkDetails = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.Drinks.Get.Replace("{drinkId}", HttpUtility.UrlEncode(drinkId)));
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            drinkDetails = JsonConvert.DeserializeObject<DrinkDetails>(reponse.Result.Content!)!.DrinkDetailsList!;
        }

        return drinkDetails.FirstOrDefault();
    }

    public static DrinkDetail? GetRandomDrinkDetail()
    {
        List<DrinkDetail> drinkDetails = [];

        using var client = new RestClient();

        var request = new RestRequest(ApiRoutes.Drinks.GetRandom);
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            drinkDetails = JsonConvert.DeserializeObject<DrinkDetails>(reponse.Result.Content!)!.DrinkDetailsList!;
        }

        return drinkDetails.FirstOrDefault();
    }
}
