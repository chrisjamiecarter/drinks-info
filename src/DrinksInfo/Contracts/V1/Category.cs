using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

public class Category
{
    [JsonProperty("strCategory")]
    public string? Name { get; set; }
}
