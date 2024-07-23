using Newtonsoft.Json;

namespace DrinksInfo.Contracts;

public class Category
{
    [JsonProperty("strCategory")]
    public string? Name { get; set; }
}
