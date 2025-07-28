using Newtonsoft.Json;

namespace DrinksInfo.Contracts.Responses.V1;

/// <summary>
/// A JSON reponse for a collection of drinks.
/// </summary>
public class DrinksResponse
{
    [JsonProperty("drinks")]
    public DrinkResponse[]? Values { get; set; }
}
