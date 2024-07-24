using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

public class Drinks
{
    [JsonProperty("drinks")]
    public List<Drink>? Values { get; set; }
}
