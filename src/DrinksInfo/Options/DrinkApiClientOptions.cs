namespace DrinksInfo.Options;

public class DrinkApiClientOptions
{
    public string Root { get; set; } = "https://www.thecocktaildb.com/api/json";
    public string Version { get; set; } = "v1";
    public string Key { get; set; } = "1";
}
