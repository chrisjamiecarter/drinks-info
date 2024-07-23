using Newtonsoft.Json;

namespace DrinksInfo.Contracts;

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink>? DrinksList { get; set; }
}
