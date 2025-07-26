using Newtonsoft.Json;

namespace DrinksInfo.Contracts.V1;

/// <summary>
/// A JSON reponse for a category.
/// </summary>
public class Category
{
    [JsonProperty("strCategory")]
    public string? Name { get; set; }
}
