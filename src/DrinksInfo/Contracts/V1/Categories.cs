using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

public class Categories
{
    [JsonProperty("drinks")]
    public Category[]? Values { get; set; }
}
