using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

/// <summary>
/// A JSON reponse for a collection of drinks.
/// </summary>
public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink>? Values { get; set; }
}
